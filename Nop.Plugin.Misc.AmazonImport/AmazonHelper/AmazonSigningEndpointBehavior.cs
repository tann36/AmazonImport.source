﻿using System;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

namespace Nop.Plugin.Misc.AmazonImport.AmazonHelper
{
	internal class AmazonSigningEndpointBehavior : IEndpointBehavior {
		private string	accessKeyId	= "";
		private string	secretKey	= "";

		public AmazonSigningEndpointBehavior(string accessKeyId, string secretKey) {
			this.accessKeyId	= accessKeyId;
			this.secretKey		= secretKey;
		}

		public void ApplyClientBehavior(ServiceEndpoint serviceEndpoint, ClientRuntime clientRuntime) {
			clientRuntime.MessageInspectors.Add(new AmazonSigningMessageInspector(accessKeyId, secretKey));
		}

		public void ApplyDispatchBehavior(ServiceEndpoint serviceEndpoint, EndpointDispatcher endpointDispatcher) { return; }
		public void Validate(ServiceEndpoint serviceEndpoint) { return; }
		public void AddBindingParameters(ServiceEndpoint serviceEndpoint, BindingParameterCollection bindingParameters) { return; }
	}
}