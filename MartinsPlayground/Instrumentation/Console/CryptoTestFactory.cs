﻿using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using Mono.Security.NewTls.TestFramework;

namespace Mono.Security.Instrumentation.Console
{
	using Framework;

	public class CryptoTestFactory : ITestParameterProvider
	{
		IList<IHashTestHost> providers;

		public Type Type {
			get { return typeof(IHashTestHost); }
		}

		public string Name {
			get { return null; }
		}

		public IEnumerable Parameters {
			get { return providers; }
		}

		public CryptoTestFactory (params string[] names)
		{
			providers = new List<IHashTestHost> ();
			if (names != null && names.Length > 0) {
				foreach (var name in names) {
					providers.Add (GetProvider (name));
				}
			} else {
				providers.Add (new MonoCryptoTest ());
				providers.Add (new NativeCryptoTest ());
			}
		}

		static IHashTestHost GetProvider (string name)
		{
			if (name == "mono")
				return new MonoCryptoTest ();
			else if (name == "openssl")
				return new NativeCryptoTest ();
			else
				throw new NotSupportedException ();
		}

		public IEnumerable GetParameters (Type fixtureType)
		{
			return providers;
		}
	}
}

