/*
 * Created by SharpDevelop.
 * User: HMSS
 * Date: 23/09/2012
 * Time: 09:37 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace ASintactico
{
	/// <summary>
	/// Description of MulFactorAST.
	/// </summary>
	public class MulFactorAST:TermAST
	{
		FactorAST fac,facs;
		public MulFactorAST(FactorAST fa, FactorAST fas)
		{
			fac=fa;
			facs=fas;
		}
	}
}
