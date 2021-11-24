using System;
using System.Collections.Generic;
using ECommerce.Orders.PactTests.XUnitHelpers;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using PactNet;
using PactNet.Infrastructure.Outputters;
using Xunit;
using Xunit.Abstractions;

namespace Ecommerce.Orders.Tests
{
    public class ProviderApiTests : IDisposable
    {
        private string _providerUri { get; }
        private string _pactServiceUri { get; }
        private IWebHost _webHost { get; }
        private ITestOutputHelper outputHelper { get; }

        private readonly bool isCI = true;
        public ProviderApiTests(ITestOutputHelper output)
        {
           
           // _providerUri = "http://localhost:49842";
            _pactServiceUri = "http://localhost:49842";
            outputHelper = output;

            /*_webHost = WebHost.CreateDefaultBuilder()
                .UseUrls(_pactServiceUri)
                .Build();

            _webHost.Start();*/
        }

        [Fact]
        public void EnsureProviderApiHonoursPactWithConsumer()
        {
            const string serviceUri = "https://localhost:44374";

            var pactUriOptions = new PactUriOptions()
            .SetBasicAuthentication("pactbroker", "pactbroker");

            var config = new PactVerifierConfig
            {


                ProviderVersion = "1", //NOTE: Setting a provider version is required for publishing verification results
                PublishVerificationResults = isCI,
                Outputters = new List<IOutput> //NOTE: We default to using a ConsoleOutput, however xUnit 2 does not capture the console output, so a custom outputter is required.
                    {
                        new XUnitOutput(outputHelper)
                    },
                 //   CustomHeaders = new Dictionary<string, string> { { "Authorization", "Basic VGVzdA==" } }, //This allows the user to set request headers that will be sent with every request the verifier sends to the provider
                    Verbose = true //Output verbose verification logs to the test output
                };

           
                //Act / Assert
                IPactVerifier pactVerifier = new PactVerifier(config);

               
                pactVerifier
                  //  .ProviderState($"{serviceUri}/provider-states")
                    .ServiceProvider("DotNetProductService", serviceUri)
                    .HonoursPactWith("FrontendWebsite")
                    
                    //or
                  //  .PactUri("http://pact-broker/pacts/provider/Something%20Api/consumer/Consumer/latest") //You can specify a http or https uri
                                                                                                           //or
                  //  .PactUri("http://pact-broker/pacts/provider/Something%20Api/consumer/Consumer/latest", pactUriOptions) //With options decribed above
                                                                                                                           //or (if you're using the Pact Broker, you can use the various different features, including pending pacts)
                    .PactBroker("http://localhost:80", uriOptions: pactUriOptions)
                    .Verify();
            
        
    }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls
        

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    
                }

                disposedValue = true;
            }
        }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
        }
        #endregion
    }
}
