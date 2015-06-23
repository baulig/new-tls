﻿//
// InstrumentCollection.cs
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
using System.Collections.Generic;

namespace Mono.Security.NewTls.Instrumentation
{
	public class InstrumentCollection
	{
		SettingsInstrument settings;
		SignatureInstrument signatureInstrument;
		HashSet<HandshakeInstrumentType> handshakeInstruments = new HashSet<HandshakeInstrumentType> ();

		public bool HasSettings {
			get { return settings != null; }
		}

		public SettingsInstrument Settings {
			get {
				if (settings == null)
					Interlocked.CompareExchange<SettingsInstrument> (ref settings, new SettingsInstrument (), null);
				return settings;
			}
		}

		public bool HasSignatureInstrument {
			get { return signatureInstrument != null; }
		}

		public SignatureInstrument SignatureInstrument {
			get {
				if (signatureInstrument == null)
					Interlocked.CompareExchange<SignatureInstrument> (ref signatureInstrument, new SignatureInstrument (), null);
				return signatureInstrument;
			}
		}

		public void Install (HandshakeInstrumentType type)
		{
			handshakeInstruments.Add (type);
		}

		public bool HasInstrument (HandshakeInstrumentType type)
		{
			return handshakeInstruments.Contains (type);
		}
	}
}

