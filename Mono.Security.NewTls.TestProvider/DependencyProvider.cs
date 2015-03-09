﻿//
// DependencyProvider.cs
//
// Author:
//       Martin Baulig <martin.baulig@xamarin.com>
//
// Copyright (c) 2015 Xamarin, Inc.
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
using System;
using System.Threading;
using Xamarin.AsyncTests;
using Mono.Security.Interface;
using Mono.Security.Providers.NewTls;

[assembly: DependencyProvider (typeof (Mono.Security.NewTls.TestProvider.DependencyProvider))]

namespace Mono.Security.NewTls.TestProvider
{
	using TestFramework;

	public class DependencyProvider : IDependencyProvider
	{
		static int initialized;

		public void Initialize ()
		{
			if (Interlocked.CompareExchange (ref initialized, 1, 0) == 0) {
				var newTlsProvider = new NewTlsProvider ();
				DependencyInjector.Register<NewTlsProvider> (newTlsProvider);
				MonoTlsProviderFactory.InstallProvider (newTlsProvider);

				DependencyInjector.Register<ICryptoProvider> (new CryptoProvider ());
				DependencyInjector.Register<IConnectionProvider> (new ConnectionProvider ());
			}
		}
	}
}

