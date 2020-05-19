using System;
using System.Threading;
using System.Threading.Tasks;
using Fivet.ZeroIce.model;
using Ice;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Fivet.Server
{
    internal class FivetService : IHostedService
    {

        /// <summary>
        /// The Logger.
        /// </summary>
        private readonly ILogger<FivetService> _logger;

        /// <summary>
        /// The Port.
        /// </summary>
        private readonly int _port = 8080;

        /// <summary>
        /// The Communicator.
        /// </summary>
        private readonly Communicator _communicator;


        /// <summary>
        /// The FivetService.
        /// </summary>
        /// <param name="logger">Used to print debug message.</param>
        public FivetService(ILogger<FivetService> logger)
        {
            _logger = logger;
            _communicator = buildCommunicator();
        }


        /// <summary>
        /// Triggered when the application host is ready to start the service.
        /// </summary>
        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogDebug("Starting the FivetService ..");

            // The adapter: https://doc.zeroc.com/ice/3.7/client-side-features/proxies/proxy-and-endpoint-syntax
            // tcp (protocol) -z (compression) -t 15000 (timeout in ms) -p 8080 (port to bind)
            var adapter = _communicator.createObjectAdapterWithEndpoints("TheSystem", "tcp -z -t 15000 -p " + _port);

            // The interface
            TheSystem theSystem = new TheSystemImpl();

            // Register in the communicator
            adapter.add(theSystem, Util.stringToIdentity("TheSystem"));

            // Activation
            adapter.activate();

            // All ok
            return Task.CompletedTask;
        }


        /// <summary>
        /// Triggered when the application host is performing a graceful shutdown.
        /// </summary>
        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogDebug("Stopping the FivetService ..");

            _communicator.shutdown();

            _logger.LogDebug("Communicator Stopper!");

            return Task.CompletedTask;
        }


        /// <summary>
        /// Build the communicator.
        /// </summary>
        /// <returns>The Communicator</returns>
        private Communicator buildCommunicator()
        {
            _logger.LogDebug("Initializating Communicator v{0} ({1}) ..", Ice.Util.stringVersion(), Ice.Util.intVersion());

            // ZeroC properties
            Properties properties = Util.createProperties();
            // properties.setProperty("Ice.Trace.Network", "3");

            InitializationData initializationData = new InitializationData();
            initializationData.properties = properties;

            return Ice.Util.initialize(initializationData);
        }
    }
    

    /// <summary>
    /// The Implementation of TheSystem interface.
    /// </summary>
    public class TheSystemImpl : TheSystemDisp_
    {
        
        /// <summary>
        /// Return the difference in the time.
        /// </summary>
        /// <param name="clienTime"></param>
        /// <param name="current"></param>
        /// <returns>The Delay</returns>
        public override long getDelay(long clientTime, Current current = null)
        {
            return DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() - clientTime;
        }
    }

}