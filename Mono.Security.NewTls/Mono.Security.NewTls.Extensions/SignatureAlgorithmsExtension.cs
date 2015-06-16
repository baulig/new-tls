﻿using System;
using System.Collections.Generic;

namespace Mono.Security.NewTls.Extensions
{
	public class SignatureAlgorithmsExtension : TlsExtension
	{
		public override ExtensionType ExtensionType {
			get { return ExtensionType.SignatureAlgorithms; }
		}

		public SignatureParameters SignatureParameters {
			get;
			private set;
		}

		public SignatureAlgorithmsExtension (TlsBuffer incoming)
		{
			var length = incoming.ReadInt16 ();
			if ((length % 2) != 0)
				throw new TlsException (AlertDescription.DecodeError);

			SignatureParameters = new SignatureParameters ();

			var count = length >> 1;
			for (int i = 0; i < count; i++) {
				SignatureParameters.SignatureAndHashAlgorithms.Add (new SignatureAndHashAlgorithm (incoming));
			}
 		}

		public SignatureAlgorithmsExtension (SignatureParameters parameters)
		{
			SignatureParameters = parameters;
		}

		public override void Encode (TlsBuffer buffer)
		{
			var algorithms = SignatureParameters.SignatureAndHashAlgorithms;
			buffer.Write ((short)ExtensionType);
			buffer.Write ((short)(algorithms.Count * 2 + 2));
			buffer.Write ((short)(algorithms.Count * 2));
			foreach (var algorithm in algorithms)
				algorithm.Encode (buffer);
		}

		public override bool ProcessClient (TlsContext context)
		{
			// We must never get this from a server.
			throw new TlsException (AlertDescription.UnsupportedExtension);
		}

		public override TlsExtension ProcessServer (TlsContext context)
		{
			context.HandshakeParameters.SignatureParameters = SignatureParameters;
			return this;
		}
	}
}

