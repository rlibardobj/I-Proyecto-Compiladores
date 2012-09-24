/*
 * Created by SharpDevelop.
 * User: rlibardobj
 * Date: 15/09/2012
 * Time: 07:57 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.IO;

namespace ASintactico
{
	/// <summary>
	/// Description of Prueba.
	/// </summary>
	public class Prueba
	{
    	public static void Main(string[] argv)
    	{
    	Scanner yy = new Scanner(new StreamReader(Console.ReadLine()));
		Token t;
		do {
			t=yy.nextToken();
			System.Console.WriteLine(t.value);
		} while (t.type != 43);
		Console.ReadLine();
	}
}
}
