using NBitcoin.DataEncoders;
using System.Linq;
using NBitcoin.Protocol;
using System;
using System.Net;
using System.Collections.Generic;

namespace NBitcoin.Viacoin
{
	public class Networks
	{
		//Format visual studio
		//{({.*?}), (.*?)}
		//Tuple.Create(new byte[]$1, $2)
		static Tuple<byte[], int>[] pnSeed6_main = {
	Tuple.Create(new byte[]{0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0xff,0xff,0x05,0x65,0x6a,0x35}, 5223),
	Tuple.Create(new byte[]{0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0xff,0xff,0x52,0xc4,0x0b,0xc9}, 5223),
	Tuple.Create(new byte[]{0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0xff,0xff,0x6b,0xaa,0xad,0x9d}, 5223),
	Tuple.Create(new byte[]{0xfd,0x87,0xd8,0x7e,0xeb,0x43,0x8c,0x14,0xde,0x2c,0x7d,0x6b,0xc0,0xa3,0xdc,0xf7}, 5223),
	Tuple.Create(new byte[]{0xfd,0x87,0xd8,0x7e,0xeb,0x43,0x9b,0x65,0xda,0xa4,0x3d,0xf5,0x2f,0x21,0x89,0xd5}, 5223),
	Tuple.Create(new byte[]{0xfd,0x87,0xd8,0x7e,0xeb,0x43,0x0d,0xfd,0x43,0xe6,0xeb,0xbc,0xc3,0xe4,0xf4,0x02}, 5223)
};
		static Tuple<byte[], int>[] pnSeed6_test = {
	Tuple.Create(new byte[]{0xfd,0x87,0xd8,0x7e,0xeb,0x43,0x8c,0x95,0x7f,0x9b,0x49,0x18,0xd4,0xca,0x06,0x11}, 25223),
};

		public static void Register()
		{
			var port = 5223;
			NetworkBuilder builder = new NetworkBuilder();
			_Mainnet = builder.SetConsensus(new Consensus()
			{
				SubsidyHalvingInterval = 657000,
				MajorityEnforceBlockUpgrade = 15000,
				MajorityRejectBlockOutdated = 19000,
				MajorityWindow = 20000,
				BIP34Hash = new uint256("0x0"),
				PowLimit = new Target(new uint256("000001ffffffffffffffffffffffffffffffffffffffffffffffffffffffffff")),
				PowTargetTimespan = TimeSpan.FromSeconds(14 * 24 * 60 * 60),
				PowTargetSpacing = TimeSpan.FromSeconds(1 * 24),
				PowAllowMinDifficultyBlocks = false,
				PowNoRetargeting = false,
				RuleChangeActivationThreshold = 37800,
				MinerConfirmationWindow = 50400,
				CoinbaseMaturity = 100,
				HashGenesisBlock = new uint256("4e9b54001f9976049830128ec0331515eaabe35a70970d79971da1539a400ba1"),
				GetPoWHash = GetPoWHash
			})
			.SetBase58Bytes(Base58Type.PUBKEY_ADDRESS, new byte[] { 127 })
			.SetBase58Bytes(Base58Type.SCRIPT_ADDRESS, new byte[] { 196 })
			.SetBase58Bytes(Base58Type.SECRET_KEY, new byte[] { 255 })
			.SetBase58Bytes(Base58Type.EXT_PUBLIC_KEY, new byte[] { 0x04, 0x35, 0x87, 0xCF })
			.SetBase58Bytes(Base58Type.SECRET_KEY, new byte[] { 0x04, 0x35, 0x83, 0x94 })
			.SetMagic(0xcbc6680f)
			.SetPort(port)
			.SetRPCPort(5222)
			.SetName("via-main")
			.AddAlias("via-mainnet")
			.AddAlias("viacoin-mainnet")
			.AddAlias("viacoin-main")
			.AddDNSSeeds(new[]
			{
				new DNSSeedData("viacoin.net", "seed.viacoin.net"),
				new DNSSeedData("barbatos.fr", "viaseeder.barbatos.fr"),
				new DNSSeedData("bootstap.viacoin.net", "mainnet.viacoin.net"),
				new DNSSeedData("zzy.su", "seed.zzy.su"),
			})
			.AddSeeds(ToSeed(pnSeed6_main))
			.SetGenesis(new Block(Encoders.Hex.DecodeData("010000000000000000000000000000000000000000000000000000000000000000000000d9ced4ed1130f7b7faad9be25323ffafa33232a17c3edf6cfd97bee6bafbdd97b9aa8e4ef0ff0f1ecd513f7c0101000000010000000000000000000000000000000000000000000000000000000000000000ffffffff4804ffff001d0104404e592054696d65732030352f4f63742f32303131205374657665204a6f62732c204170706c65e280997320566973696f6e6172792c2044696573206174203536ffffffff0100f2052a010000004341040184710fa689ad5023690c80f3a49c8f13f8d45b8c857fbcbc8bc4a8e4d3eb4b10f4d4604fa08dce601aaf0f470216fe1b51850b4acf21b179c45070ac7b03a9ac00000000")))
			.BuildAndRegister();

			builder = new NetworkBuilder();
			port = 25223;
			_Testnet = builder.SetConsensus(new Consensus()
			{
				SubsidyHalvingInterval = 657000,
				MajorityEnforceBlockUpgrade = 510,
				MajorityRejectBlockOutdated = 750,
				MajorityWindow = 1000,
				PowLimit = new Target(new uint256("00001fffffffffffffffffffffffffffffffffffffffffffffffffffffffffff")),
				PowTargetTimespan = TimeSpan.FromSeconds(3.5 * 24 * 60 * 60),
				PowTargetSpacing = TimeSpan.FromSeconds(1 * 24),
				PowAllowMinDifficultyBlocks = true,
				PowNoRetargeting = false,
				RuleChangeActivationThreshold = 9450,
				MinerConfirmationWindow = 21600,
				CoinbaseMaturity = 100,
				HashGenesisBlock = new uint256("f5ae71e26c74beacc88382716aced69cddf3dffff24f384e1808905e0188f68f"),
				GetPoWHash = GetPoWHash
			})
			.SetBase58Bytes(Base58Type.PUBKEY_ADDRESS, new byte[] { 127 })
			.SetBase58Bytes(Base58Type.SCRIPT_ADDRESS, new byte[] { 196 })
			.SetBase58Bytes(Base58Type.SECRET_KEY, new byte[] { 255 })
			.SetBase58Bytes(Base58Type.EXT_PUBLIC_KEY, new byte[] { 0x04, 0x35, 0x87, 0xCF })
			.SetBase58Bytes(Base58Type.SECRET_KEY, new byte[] { 0x04, 0x35, 0x83, 0x94 })
			.SetMagic(0x92efc5a9)
			.SetPort(port)
			.SetRPCPort(25222)
			.SetName("via-test")
			.AddAlias("via-testnet")
			.AddAlias("viacoin-test")
			.AddAlias("viacoin-testnet")
			.AddDNSSeeds(new[]
			{
				new DNSSeedData("bootstrap-testnet.viacoin.net", "testnet.viacoin.net"),
				new DNSSeedData("viacoin.net", "seed-testnet.viacoin.net"),
			})
			.AddSeeds(ToSeed(pnSeed6_test))
			.SetGenesis(new Block(Encoders.Hex.DecodeData("010000000000000000000000000000000000000000000000000000000000000000000000d9ced4ed1130f7b7faad9be25323ffafa33232a17c3edf6cfd97bee6bafbdd97f6028c4ef0ff0f1e38c3f6160101000000010000000000000000000000000000000000000000000000000000000000000000ffffffff4804ffff001d0104404e592054696d65732030352f4f63742f32303131205374657665204a6f62732c204170706c65e280997320566973696f6e6172792c2044696573206174203536ffffffff0100f2052a010000004341040184710fa689ad5023690c80f3a49c8f13f8d45b8c857fbcbc8bc4a8e4d3eb4b10f4d4604fa08dce601aaf0f470216fe1b51850b4acf21b179c45070ac7b03a9ac00000000")))
			.BuildAndRegister();
		}

		static uint256 GetPoWHash(BlockHeader header)
		{
			var headerBytes = header.ToBytes();
			var h = NBitcoin.Crypto.SCrypt.ComputeDerivedKey(headerBytes, headerBytes, 1024, 1, 1, null, 32);
			return new uint256(h);
		}

		private static IEnumerable<NetworkAddress> ToSeed(Tuple<byte[], int>[] tuples)
		{
			return tuples
					.Select(t => new NetworkAddress(new IPAddress(t.Item1), t.Item2))
					.ToArray();
		}

		private static Network _Mainnet;
		public static Network Mainnet
		{
			get
			{
				AssertRegistered();
				return _Mainnet;
			}
		}

		private static void AssertRegistered()
		{
			if(_Mainnet == null)
				throw new InvalidOperationException("You need to call ViacoinNetworks.Register() before using the viacoin networks");
		}

		private static Network _Testnet;
		public static Network Testnet
		{
			get
			{
				AssertRegistered();
				return _Testnet;
			}
		}
	}
}
