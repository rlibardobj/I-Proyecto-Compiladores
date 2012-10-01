/*
 * Created by SharpDevelop.
 * User: HMSS
 * Date: 23/09/2012
 * Time: 09:48 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace ASintactico
{
	/// <summary>
	/// Description of NewBasicFactorAST.
	/// </summary>
	public class NewBasicFactorAST:FactorAST
	{
		public TerminalesAST ident;
		
		public NewBasicFactorAST(TerminalesAST id)
		{
			ident=id;
		}
		
		public override object visit(Visitor v,object arg){
			return v.VisitNewBasicFactorAST(this,arg);
		}
	}
}
