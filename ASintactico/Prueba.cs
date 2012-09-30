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
    	parser parsing = new parser(new Scanner(new StreamReader(Console.ReadLine())));
    	ProgramAST arbol;
    	arbol=parsing.parseProgram();
	}
}
}
