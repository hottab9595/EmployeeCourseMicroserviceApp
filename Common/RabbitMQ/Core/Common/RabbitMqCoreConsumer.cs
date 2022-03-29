using System;
using System.Threading;
using System.Threading.Tasks;
using Common.RabbitMQ.Models.Common;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Common.RabbitMQ.Core.Common
{
    public abstract class RabbitMqCoreConsumer : RabbitMqCore, IHostedService, IDisposable
    {
        protected RabbitMqCoreConsumer(IOptions<RabbitMqConfigurationModel> rabbitMqOptions) : base(rabbitMqOptions)
        {
            connection.ConnectionShutdown += RabbitMQ_ConnectionShutdown;
        }

        #region Events

        protected void HandleMessage(PublishModel publishModel)
        {
        }

        protected void OnConsumerCancelled(object sender, ConsumerEventArgs e)
        {
        }

        protected void OnConsumerUnregistered(object sender, ConsumerEventArgs e)
        {
        }

        protected void OnConsumerRegistered(object sender, ConsumerEventArgs e)
        {
        }

        protected void OnConsumerShutdown(object sender, ShutdownEventArgs e)
        {
        }

        private void RabbitMQ_ConnectionShutdown(object sender, ShutdownEventArgs e)
        {
        }

        #endregion
        
        #region IHostedServiceRealization

        private Task _executeTask;
        private CancellationTokenSource _stoppingCts;

        /// <summary>
        /// Gets the Task that executes the background operation.
        /// </summary>
        /// <remarks>
        /// Will return <see langword="null"/> if the background operation hasn't started.
        /// </remarks>
        public virtual Task ExecuteTask => _executeTask;

        /// <summary>
        /// This method is called when the <see cref="IHostedService"/> starts. The implementation should return a task that represents
        /// the lifetime of the long running operation(s) being performed.
        /// </summary>
        /// <param name="stoppingToken">Triggered when <see cref="IHostedService.StopAsync(CancellationToken)"/> is called.</param>
        /// <returns>A <see cref="Task"/> that represents the long running operations.</returns>
        protected abstract Task ExecuteAsync(CancellationToken stoppingToken);


        /// <summary>
        /// Triggered when the application host is ready to start the service.
        /// </summary>
        /// <param name="cancellationToken">Indicates that the start process has been aborted.</param>
        public virtual Task StartAsync(CancellationToken cancellationToken)
        {
            // Create linked token to allow cancelling executing task from provided token
            _stoppingCts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);

            // Store the task we're executing
            _executeTask = ExecuteAsync(_stoppingCts.Token);

            // If the task is completed then return it, this will bubble cancellation and failure to the caller
            if (_executeTask.IsCompleted)
            {
                return _executeTask;
            }

            // Otherwise it's running
            return Task.CompletedTask;
        }

        /// <summary>
        /// Triggered when the application host is performing a graceful shutdown.
        /// </summary>
        /// <param name="cancellationToken">Indicates that the shutdown process should no longer be graceful.</param>
        public virtual async Task StopAsync(CancellationToken cancellationToken)
        {
            // Stop called without start
            if (_executeTask == null)
            {
                return;
            }

            try
            {
                // Signal cancellation to the executing method
                _stoppingCts.Cancel();
            }
            finally
            {
                // Wait until the task completes or the stop token triggers
                await Task.WhenAny(_executeTask, Task.Delay(Timeout.Infinite, cancellationToken)).ConfigureAwait(false);
            }

        }

        public virtual void Dispose()
        {
            channel.Close();
            connection.Close();

            _stoppingCts?.Cancel();
        }

        #endregion
    }
}