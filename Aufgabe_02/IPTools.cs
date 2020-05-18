using System;
using System.Globalization;

static class IPTools
{
	public static readonly byte[] LocalHostBytes = new byte[] { 127, 0, 0, 1 };
	public static readonly string LocalHost;

	//Format an IPv4 or IPv6 address as string:
	public static string IPAddressToString(byte[] address)
	{
		if (address.Length == 4)
		{
			return IPTools.IPv4AddressToString(address);
		}
		else
		{
			return IPTools.IPv6AddressToString(address);
		}
	}

	//Format an IP address (four-byte-array) as string:
	public static string IPv4AddressToString(byte[] address)
	{
		//Check length:
		if (address.Length != 4)
		{
			throw new FormatException("IPv4 address must have four components.");
		}

		//Iterate over components and format as decimal string:
		string[] components = new string[address.Length];

		for (int i = 0; i < 4; i++)
		{
			components[i] = address[i].ToString();
		}

		//Concatenate all array entries using "." as separator:
		return string.Join(".", components);
	}

	//Format an IP address (six-byte-array) as string:
	public static string IPv6AddressToString(byte[] address)
	{
		//TODO
		return "";
	}

	//Parse a given string as IPv4 or IPv6 address:
	public static byte[] StringToIPAddress(string val)
	{
		if (val.Contains("."))
		{
			return IPTools.StringToIPv4Address(val);
		}
		else if (val.Contains(":"))
		{
			return IPTools.StringToIPv6Address(val);
		}
		else
		{
			throw new FormatException("Invalid IP address string");
		}
	}

	//Parse a given string as IPv4 address:
	public static byte[] StringToIPv4Address(string val)
	{
		//Split the string at all occurrences of ".":
		string[] components = val.Split('.');

		//Check length:
		if (components.Length != 4)
		{
			throw new FormatException("IPv4 address must have four components.");
		}

		//Parse from decimal strings:
		byte[] result = new byte[4];

		for (int i = 0; i < 4; i++)
		{
			result[i] = byte.Parse(components[i]);
		}

		return result;
	}

	//Parse a given string as IPv6 address:
	public static byte[] StringToIPv6Address(string val)
	{
		//TODO
		return null;
	}

	//Static constructor:
	static IPTools()
	{
		IPTools.LocalHost = IPTools.IPv4AddressToString(IPTools.LocalHostBytes);
	}
}
