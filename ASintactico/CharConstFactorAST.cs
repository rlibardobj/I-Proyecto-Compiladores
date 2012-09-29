/*
 * Created by SharpDevelop.
 * User: HMSS
 * Date: 23/09/2012
 * Time: 09:45 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace ASintactico
{
	/// <summary>
	/// Description of CharConstFactorAST.
	/// </summary>
	public class CharConstFactorAST:FactorAST
	{
		TerminalesAST charconst;
		public CharConstFactorAST(TerminalesAST charc)
		{
			charconst=charc;
		}
	}
}
