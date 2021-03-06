﻿using System.Collections.Generic;

namespace Mono.Security.NewTls.TestFramework
{
	public interface IServerParameters : IConnectionParameters
	{
		IServerCertificate ServerCertificate {
			get; set;
		}

		bool AskForClientCertificate {
			get; set;
		}

		bool RequireClientCertificate {
			get; set;
		}

		ICollection<CipherSuiteCode> ServerCiphers {
			get; set;
		}
	}
}

