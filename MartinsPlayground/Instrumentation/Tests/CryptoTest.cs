﻿using System;
using System.Security.Cryptography;
using Mono.Security.NewTls;
using Mono.Security.NewTls.Cipher;
using Mono.Security.NewTls.TestFramework;
using NUnit.Framework;

namespace Mono.Security.Instrumentation.Tests
{
	using Framework;

	[Category ("Crypto")]
	[ParameterizedTestFixture (typeof (IHashTestHost))]
	public class CryptoTest
	{
		public TestConfiguration Configuration {
			get;
			private set;
		}

		public IHashTestHost Provider {
			get;
			private set;
		}

		public CryptoTest (TestConfiguration config, IHashTestHost provider)
		{
			Configuration = config;
			Provider = provider;
		}

		#region Auto-Generated

		const string TestSeed1 = "master secret";

		static readonly byte[] TestSecret1 = new byte[] {
			0xbc, 0x43, 0x2c, 0x14, 0xb2, 0xd4, 0xfd, 0x1f, 0xfa, 0xab, 0xb1, 0x2a, 0x1d, 0x82, 0xad, 0x35,
			0x05, 0xda, 0x85, 0x59, 0xde, 0xf4, 0x10, 0x32, 0x0b, 0x50, 0x43, 0x88, 0x0c, 0x08, 0x0f, 0xfe,
			0xf9, 0x57, 0x47, 0xd9, 0x79, 0x6e, 0xf6, 0x7c, 0x48, 0x6d, 0xb6, 0xf5, 0x48, 0xe4, 0x84, 0x66,
			0x12, 0x06, 0xc5, 0x1c, 0x82, 0xaf, 0xcc, 0x93, 0x50, 0x77, 0x95, 0x03, 0x9f, 0xca, 0x9c, 0x64,
			0x35, 0xb9, 0xfc, 0x88, 0x76, 0x91, 0x68, 0xc3, 0xf4, 0xf7, 0x41, 0x79, 0x16, 0xd1, 0xb5, 0x00,
			0xc8, 0x6f, 0x03, 0x42, 0xf1, 0xd5, 0x01, 0xea, 0x44, 0x0a, 0x35, 0xc5, 0xc6, 0x88, 0x58, 0xa9,
			0x64, 0xcb, 0x24, 0x0b, 0x42, 0xde, 0x47, 0x45, 0xad, 0x20, 0x53, 0x97, 0xf5, 0x1c, 0xae, 0x2c,
			0x47, 0xbe, 0x05, 0xaf, 0xa2, 0xba, 0x8f, 0x92, 0x55, 0xc8, 0xb8, 0x0a, 0xcb, 0xcf, 0x23, 0x7d
		};

		static readonly byte[] TestData1 = new byte[] {
			0x6d, 0x10, 0x72, 0xed, 0xc0, 0x7c, 0xd2, 0x6f, 0xd5, 0x7f, 0xd2, 0x57, 0x23, 0xfd, 0x1c, 0x10,
			0x29, 0xb8, 0xdf, 0x88, 0x81, 0xf3, 0x7d, 0xc2, 0x63, 0x13, 0x2d, 0x65, 0x96, 0x92, 0x30, 0x14,
			0x47, 0x8c, 0xc7, 0xdf, 0xde, 0x53, 0xb4, 0xd8, 0x0b, 0x9a, 0x9c, 0xd8, 0xb7, 0xef, 0xaf, 0x08,
			0xb1, 0xcf, 0x25, 0x1b, 0xc2, 0xec, 0x3c, 0xd5, 0xdb, 0x36, 0xd2, 0xee, 0xf2, 0x30, 0xc7, 0x10
		};

		static readonly byte[] PRF1 = new byte[] {
			0x42, 0x79, 0x9e, 0xf8, 0x2c, 0xdf, 0xcb, 0x2d, 0xf8, 0xcf, 0x4c, 0x6e, 0xf0, 0x4d, 0xe0, 0xa1,
			0x86, 0x6e, 0x5b, 0xa4, 0x53, 0x80, 0xb7, 0x00, 0x5e, 0xed, 0xa6, 0x6f, 0x36, 0xc9, 0x56, 0x21,
			0xd4, 0xfd, 0xe2, 0x62, 0xbb, 0xd7, 0xe1, 0xd4, 0x6b, 0xd2, 0xd6, 0x51, 0x53, 0x7d, 0xf6, 0x1f
		};

		const string TestSeed2 = "key expansion";

		static readonly byte[] TestSecret2 = new byte[] {
			0xfc, 0xa2, 0x47, 0x45, 0xe8, 0x94, 0x30, 0x83, 0x76, 0xea, 0x78, 0xe8, 0x88, 0x00, 0x67, 0x8f,
			0xd9, 0xd4, 0x6c, 0x62, 0x7d, 0x48, 0x2d, 0x64, 0x38, 0xb9, 0x4d, 0x40, 0xac, 0xb3, 0x47, 0x09,
			0xbe, 0x13, 0x28, 0x3c, 0x78, 0xe6, 0x17, 0xda, 0x97, 0xb8, 0x82, 0xea, 0xe5, 0x9e, 0xaf, 0x07,
			0x97, 0xb6, 0xd3, 0xf6, 0x84, 0xda, 0xf2, 0xb8, 0x98, 0x9d, 0xce, 0xec, 0xeb, 0xb0, 0x05, 0xb6,
			0x91, 0xec, 0xfa, 0x9d, 0xe5, 0x24, 0xe5, 0xd0, 0x80, 0x16, 0x19, 0x4c, 0x3a, 0xa8, 0xf6, 0xad,
			0xbb, 0x01, 0x7a, 0x00, 0x9c, 0xea, 0xbf, 0xdb, 0x77, 0x8b, 0x59, 0x72, 0x3f, 0x2b, 0x76, 0x22,
			0x0a, 0xa6, 0x1e, 0x81, 0x8a, 0x9d, 0x93, 0xe7, 0x35, 0x8f, 0x16, 0x4e, 0xbd, 0x3b, 0xd2, 0x84,
			0x4d, 0x79, 0x93, 0x86, 0x1a, 0xc6, 0x35, 0x3c, 0x45, 0x6c, 0xb5, 0xe6, 0x92, 0x3a, 0xb1, 0xaf
		};

		static readonly byte[] TestData2 = new byte[] {
			0x69, 0xc4, 0xd8, 0xe0, 0x29, 0x8d, 0x5f, 0xee, 0x52, 0xda, 0xde, 0xa4, 0xc8, 0x09, 0x74, 0xd8,
			0xb6, 0x0f, 0x1f, 0x5e, 0xe2, 0x73, 0xb6, 0x55, 0x28, 0x9c, 0x9c, 0x04, 0xd2, 0x7c, 0xbf, 0xda,
			0x72, 0xf9, 0x3c, 0x81, 0x74, 0xdf, 0xb3, 0x53, 0x58, 0x0d, 0x88, 0xeb, 0x4c, 0x9c, 0x2b, 0x54,
			0x6c, 0xda, 0x15, 0xcc, 0x47, 0x7a, 0x28, 0xee, 0x7c, 0xac, 0x25, 0xd5, 0x7b, 0xc2, 0x10, 0xcb
		};

		static readonly byte[] KeyExpansion2 = new byte[] {
			0xbe, 0xea, 0xd2, 0x6e, 0xa5, 0xfa, 0xa6, 0x4a, 0xf5, 0x1d, 0x51, 0x33, 0x21, 0x5a, 0xac, 0x63,
			0x6f, 0x48, 0x69, 0xc6, 0xc6, 0x59, 0x64, 0x92, 0xaf, 0x9b, 0x0b, 0xe5, 0x3a, 0xbc, 0x20, 0x62,
			0x6a, 0xc7, 0x34, 0x50, 0x32, 0x3c, 0x39, 0xc9, 0x49, 0xde, 0xdc, 0x31, 0x2f, 0xf2, 0x5e, 0xb1,
			0xde, 0x9a, 0xa1, 0x8f, 0xa1, 0xd2, 0x34, 0xf3, 0x68, 0x0a, 0xee, 0xb5, 0xd3, 0xc4, 0x30, 0x7f,
			0xef, 0x6d, 0xe3, 0xdd, 0x4f, 0x50, 0x61, 0x8b, 0x03, 0x9a, 0x27, 0x8a, 0x82, 0x8c, 0xbf, 0x6b,
			0xa1, 0x5e, 0x28, 0xd4, 0xac, 0x74, 0xa7, 0xbd, 0xf8, 0x16, 0xa8, 0xa0, 0xb2, 0x79, 0x59, 0xd8,
			0xcf, 0xd0, 0xf0, 0xa3, 0xc4, 0xc9, 0xf2, 0x37, 0x52, 0x65, 0x95, 0xc2, 0x12, 0x16, 0xf0, 0x28,
			0x08, 0x06, 0x9e, 0x62, 0xd3, 0xdf, 0x6a, 0x3a, 0x0e, 0x10, 0xdd, 0x6e, 0x48, 0x14, 0x71, 0x6c,
			0xcb, 0x64, 0x21, 0xc1, 0xa3, 0x3c, 0xce, 0x64, 0x46, 0xba, 0x08, 0x90, 0x24, 0x9d, 0x0e, 0x74,
			0x21, 0xec, 0xce, 0x7d
		};

		const string TestSeed3 = "master secret";

		static readonly byte[] TestSecret3 = new byte[] {
			0x75, 0x04, 0x68, 0xa4, 0xea, 0x0d, 0x2f, 0xec, 0x1c, 0x84, 0x55, 0xe0, 0xd8, 0x98, 0x22, 0xb4,
			0xa9, 0xa3, 0xa4, 0x5f, 0x3d, 0x31, 0x81, 0xdd, 0xc6, 0x21, 0x0a, 0xfa, 0xc8, 0x15, 0x83, 0xd9,
			0xde, 0xcd, 0x4d, 0x33, 0xaa, 0x60, 0xa1, 0x66, 0x2e, 0x7f, 0xf4, 0xc4, 0xfa, 0xce, 0xfa, 0x79,
			0xb0, 0x79, 0x72, 0x11, 0xba, 0xcb, 0x5b, 0xe3, 0x1d, 0x13, 0xef, 0x17, 0x54, 0x0f, 0xce, 0x1b,
			0x27, 0x6b, 0x9b, 0x72, 0xca, 0xf9, 0xd8, 0x07, 0x5b, 0xdf, 0x4d, 0xc8, 0x16, 0x67, 0x65, 0xf4,
			0x98, 0xdc, 0x6f, 0xda, 0xbe, 0x57, 0xec, 0x11, 0xd5, 0x12, 0xb9, 0xda, 0xd9, 0x90, 0xe4, 0x0f,
			0x98, 0x6c, 0x9a, 0x53, 0xf3, 0x64, 0x61, 0x24, 0x1c, 0x7d, 0xc8, 0x56, 0x39, 0xc7, 0xc2, 0xeb,
			0x40, 0x9a, 0xf0, 0x9a, 0x88, 0x34, 0x58, 0x90, 0x76, 0x80, 0xdb, 0x51, 0x90, 0xe0, 0x0c, 0x12
		};

		static readonly byte[] TestData3 = new byte[] {
			0xb1, 0x50, 0x36, 0x0a, 0xe5, 0x84, 0x0d, 0x04, 0x15, 0xb5, 0x91, 0x61, 0xc6, 0xef, 0x4e, 0x7f,
			0xb5, 0xc8, 0x2e, 0xc5, 0x7a, 0x83, 0x56, 0x61, 0x52, 0x98, 0x2d, 0xa1, 0x15, 0x2e, 0x7e, 0xba,
			0x6f, 0x54, 0x2e, 0x3c, 0xb2, 0x5d, 0x24, 0xbc, 0x17, 0x7e, 0x11, 0x99, 0xb8, 0xf7, 0x3e, 0xf7,
			0xed, 0xe1, 0x79, 0xb6, 0x38, 0x39, 0x3f, 0x17, 0x2b, 0xde, 0x52, 0xb0, 0xfe, 0x70, 0x14, 0x2f
		};

		static readonly byte[] PRF3 = new byte[] {
			0xef, 0x59, 0xb8, 0xa5, 0x80, 0xc3, 0xde, 0x41, 0xf4, 0x8c, 0x26, 0x31, 0x97, 0x2c, 0x5c, 0xf9,
			0xb6, 0x46, 0x3d, 0x2e, 0x88, 0xa7, 0x73, 0x73, 0x99, 0xfd, 0x2b, 0x62, 0x54, 0x19, 0x2b, 0x94,
			0xae, 0xa4, 0xa3, 0xed, 0xc7, 0x8c, 0x69, 0xc3, 0x1f, 0x3e, 0xff, 0xf7, 0x08, 0x43, 0xd1, 0x09
		};

		static readonly byte[] TestData4 = new byte[] {
			0x24, 0x6c, 0x19, 0x0b, 0xa7, 0x2e, 0xf7, 0x0f, 0xab, 0x3c, 0xc1, 0x30, 0x13, 0x71, 0x8c, 0x28,
			0xce, 0x77, 0xc9, 0xba, 0x55, 0x89, 0xdc, 0x46, 0xb8, 0xd5, 0xe5, 0x35, 0x80, 0xef, 0x32, 0x01,
			0x22, 0x9c, 0x83, 0xfd, 0x5d, 0x92, 0x93, 0xe4, 0x37, 0xf3, 0x04, 0xb1, 0xf0, 0xbf, 0x5b, 0x56,
			0xfb, 0x13, 0x5f, 0x0a, 0x6e, 0x04, 0x47, 0xed, 0xa7, 0x9a, 0x3b, 0xa1, 0xee, 0xe8, 0x2c, 0x46
		};

		static readonly byte[] Digest4 = new byte[] {
			0xcc, 0xe6, 0x10, 0x02, 0x40, 0x92, 0xb8, 0x66, 0x65, 0xe5, 0x03, 0x1b, 0x46, 0x8b, 0x9e, 0x50,
			0x49, 0x88, 0xcc, 0xad, 0x9d, 0x0b, 0xa6, 0xbe, 0x93, 0x6a, 0xec, 0x50, 0xfb, 0x54, 0x8c, 0xe7
		};

		static readonly byte[] TestData5 = new byte[] {
			0x17, 0x2d, 0x3f, 0x98, 0x13, 0xce, 0xec, 0x1d, 0x43, 0x0d, 0x3f, 0xbb, 0xc3, 0xdc, 0x36, 0x97,
			0x25, 0x93, 0x7a, 0xaf, 0xd1, 0x30, 0x2f, 0xe5, 0xe5, 0xda, 0x32, 0x3a, 0xaa, 0x46, 0xdc, 0xee,
			0x8b, 0xd7, 0x8f, 0x95, 0xa8, 0xda, 0xfd, 0x38, 0xaa, 0x3c, 0x2c, 0x35, 0x94, 0xa7, 0xa7, 0x39,
			0x9a, 0x15, 0x53, 0x49, 0xc1, 0x82, 0x7b, 0xb7, 0x44, 0xf4, 0xaa, 0x67, 0xf3, 0x25, 0xce, 0xf4
		};

		static readonly byte[] Digest5 = new byte[] {
			0x41, 0x03, 0xc8, 0xae, 0x02, 0x40, 0xd4, 0x2a, 0x1e, 0x87, 0x26, 0x13, 0x8d, 0x48, 0x97, 0x19,
			0xf7, 0xf2, 0x89, 0x4d, 0x48, 0x80, 0x4f, 0xe3, 0xb8, 0x7c, 0x05, 0xf3, 0x1c, 0x79, 0xed, 0x82,
			0x23, 0x80, 0x57, 0xc1, 0x39, 0x46, 0xc0, 0x8a, 0x3f, 0x36, 0x9f, 0xf2, 0x28, 0xb4, 0xce, 0xab
		};

		const string TestSeed6 = "key expansion";

		static readonly byte[] TestSecret6 = new byte[] {
			0x1c, 0x11, 0xb0, 0x7f, 0xb6, 0xfa, 0xc7, 0xcd, 0xbd, 0x08, 0x1c, 0xe7, 0x0d, 0x73, 0x7c, 0xaf,
			0xfd, 0xaf, 0x79, 0x38, 0x1b, 0x1b, 0x8b, 0x4c, 0x06, 0x38, 0x35, 0x54, 0xb2, 0x03, 0x4c, 0xbf,
			0xe7, 0x6a, 0xa2, 0xb6, 0xc7, 0x98, 0xe4, 0x10, 0x40, 0x80, 0x24, 0x84, 0x45, 0xb1, 0x2c, 0xb9,
			0x46, 0x36, 0x01, 0xa3, 0x03, 0xc3, 0xf6, 0x04, 0x16, 0xfa, 0xda, 0xaf, 0xd3, 0x78, 0x9e, 0xd6,
			0x26, 0x6b, 0x2d, 0x26, 0xc9, 0x24, 0x6d, 0x2f, 0xc2, 0xf3, 0x19, 0xda, 0x87, 0xcd, 0x30, 0xd9,
			0xf3, 0x70, 0xb4, 0x94, 0xa2, 0x63, 0x27, 0xc1, 0x31, 0xc3, 0x3c, 0xbd, 0x8e, 0xd7, 0xa9, 0x97,
			0x7e, 0x30, 0x96, 0x56, 0xd7, 0x12, 0xce, 0x1d, 0x93, 0xce, 0xf3, 0x66, 0xa5, 0x78, 0xac, 0x7d,
			0xdb, 0xea, 0x18, 0x1d, 0x49, 0x8e, 0x9f, 0x8d, 0xd0, 0x18, 0x88, 0x79, 0x9f, 0xb0, 0xdf, 0x89
		};

		static readonly byte[] TestData6 = new byte[] {
			0x6d, 0x42, 0x2a, 0x3e, 0x46, 0x68, 0xb6, 0xcc, 0xfb, 0x7e, 0x95, 0x25, 0x90, 0x18, 0x0b, 0x2c,
			0x3a, 0xfa, 0xf6, 0xdf, 0xe5, 0xbf, 0xed, 0x22, 0xa4, 0xb4, 0x77, 0xba, 0x71, 0xe7, 0xbc, 0x12,
			0x18, 0x36, 0x2f, 0x07, 0xde, 0x92, 0x20, 0x39, 0x67, 0x52, 0xfb, 0x64, 0xce, 0xc2, 0x06, 0x7a,
			0x6b, 0x0c, 0xa1, 0x6f, 0x8c, 0x5b, 0x7c, 0xf0, 0x46, 0x56, 0x40, 0xe8, 0x15, 0x6c, 0xc8, 0x80
		};

		static readonly byte[] KeyExpansion6 = new byte[] {
			0x61, 0x1d, 0xa9, 0x24, 0x77, 0xd2, 0xd1, 0xe4, 0x8f, 0x28, 0xd5, 0x2c, 0xe0, 0x56, 0xc5, 0x2f,
			0x13, 0x6d, 0x40, 0x45, 0x10, 0x25, 0x6f, 0xd5, 0x13, 0x34, 0x43, 0xf2, 0x8b, 0x91, 0xae, 0xe2,
			0x39, 0x8c, 0xb6, 0x41, 0x52, 0x0b, 0x8a, 0x2d, 0x9e, 0x35, 0x23, 0xb5, 0xa0, 0xa4, 0xe1, 0x81,
			0xc5, 0x72, 0xc0, 0x9d, 0x08, 0xff, 0x36, 0x47, 0x46, 0xea, 0x0b, 0x54, 0x05, 0x61, 0xea, 0x19,
			0x37, 0x67, 0x8f, 0x0c, 0x8f, 0xda, 0x54, 0xcb
		};

		// Call this function to randomly generate these byte arrays.
		public static void Generate (IHashTestHost provider)
		{
			var rng = RandomNumberGenerator.Create ();

			var seed1 = "master secret";
			DebugHelper.WriteCSharp ("TestSeed1", seed1);

			var secret1 = new byte [128];
			rng.GetBytes (secret1);
			DebugHelper.WriteCSharp ("TestSecret1", secret1);

			var data1 = new byte [64];
			rng.GetBytes (data1);
			DebugHelper.WriteCSharp ("TestData1", data1);

			var output1 = provider.TestPRF (HandshakeHashType.SHA256, secret1, seed1, data1, 48);
			DebugHelper.WriteCSharp ("PRF1", output1);

			var seed2 = "key expansion";
			DebugHelper.WriteCSharp ("TestSeed2", seed2);

			var secret2 = new byte [128];
			rng.GetBytes (secret2);
			DebugHelper.WriteCSharp ("TestSecret2", secret2);

			var data2 = new byte [64];
			rng.GetBytes (data2);
			DebugHelper.WriteCSharp ("TestData2", data2);

			var output2 = provider.TestPRF (HandshakeHashType.SHA256, secret2, seed2, data2, 148);
			DebugHelper.WriteCSharp ("KeyExpansion2", output2);

			var seed3 = "master secret";
			DebugHelper.WriteCSharp ("TestSeed3", seed3);

			var secret3 = new byte [128];
			rng.GetBytes (secret3);
			DebugHelper.WriteCSharp ("TestSecret3", secret3);

			var data3 = new byte [64];
			rng.GetBytes (data3);
			DebugHelper.WriteCSharp ("TestData3", data3);

			var output3 = provider.TestPRF (HandshakeHashType.SHA384, secret3, seed3, data3, 48);
			DebugHelper.WriteCSharp ("PRF3", output3);

			var data4 = new byte [64];
			rng.GetBytes (data4);
			DebugHelper.WriteCSharp ("TestData4", data4);

			var output4 = provider.TestDigest (HandshakeHashType.SHA256, data4);
			DebugHelper.WriteCSharp ("Digest4", output4);

			var data5 = new byte [64];
			rng.GetBytes (data5);
			DebugHelper.WriteCSharp ("TestData5", data5);

			var output5 = provider.TestDigest (HandshakeHashType.SHA384, data5);
			DebugHelper.WriteCSharp ("Digest5", output5);

			var seed6 = "key expansion";
			DebugHelper.WriteCSharp ("TestSeed6", seed6);

			var secret6 = new byte [128];
			rng.GetBytes (secret6);
			DebugHelper.WriteCSharp ("TestSecret6", secret6);

			var data6 = new byte [64];
			rng.GetBytes (data6);
			DebugHelper.WriteCSharp ("TestData6", data6);

			var output6 = provider.TestPRF (HandshakeHashType.SHA384, secret6, seed6, data6, 72);
			DebugHelper.WriteCSharp ("KeyExpansion6", output6);
		}

		#endregion

		[Test]
		public void TestMasterSecret_Sha256 ()
		{
			var output = Provider.TestPRF (HandshakeHashType.SHA256, TestSecret1, TestSeed1, TestData1, PRF1.Length);
			Assert.That (output, Is.EqualTo (PRF1));
		}

		[Test]
		public void TestKeyExpansion_Sha256 ()
		{
			var output = Provider.TestPRF (HandshakeHashType.SHA256, TestSecret2, TestSeed2, TestData2, KeyExpansion2.Length);
			Assert.That (output, Is.EqualTo (KeyExpansion2));
		}

		[Test]
		public void TestDigest_Sha256 ()
		{
			var output = Provider.TestDigest (HandshakeHashType.SHA256, TestData4);
			Assert.That (output, Is.EqualTo (Digest4));
		}

		[Test]
		public void TestDigest_Sha384 ()
		{
			var output = Provider.TestDigest (HandshakeHashType.SHA384, TestData5);
			Assert.That (output, Is.EqualTo (Digest5));
		}

		[Test]
		public void TestMasterSecret_Sha384 ()
		{
			var output = Provider.TestPRF (HandshakeHashType.SHA384, TestSecret3, TestSeed3, TestData3, PRF3.Length);
			Assert.That (output, Is.EqualTo (PRF3));
		}

		[Test]
		public void TestKeyExpansion_Sha384 ()
		{
			var output = Provider.TestPRF (HandshakeHashType.SHA384, TestSecret6, TestSeed6, TestData6, KeyExpansion6.Length);
			Assert.That (output, Is.EqualTo (KeyExpansion6));
		}

	}
}

