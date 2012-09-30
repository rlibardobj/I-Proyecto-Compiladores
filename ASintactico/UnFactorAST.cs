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
	/// Description of UnFactorAST.
	/// </summary>
	public class UnFactorAST:TermAST
	{
		FactorAST factor;
		public UnFactorAST(FactorAST fac)
		{
			factor=fac;
		}
		
		public override object visit(Visitor v,object arg){
			return v.VisitUnFactorAST(this,arg);
		}
	}
}
