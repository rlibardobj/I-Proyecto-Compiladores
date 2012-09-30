/*
 * Created by SharpDevelop.
 * User: rlibardobj
 * Date: 30/09/2012
 * Time: 03:05 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace ASintactico
{
	/// <summary>
	/// Description of BOOLAST.
	/// </summary>
	public class BOOLAST:TerminalesAST
	{
		string value;
		public BOOLAST(string valor)
		{
			value=valor;
		}
	}
}
