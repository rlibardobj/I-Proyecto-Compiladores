/*
 * Created by SharpDevelop.
 * User: HMSS
 * Date: 23/09/2012
 * Time: 09:42 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace ASintactico
{
	/// <summary>
	/// Description of DesigPAFactorAST.
	/// </summary>
	public class DesigPAFactorAST:FactorAST
	{
		public DesignatorAST desig;
		public ActParsAST pars;
		
		public DesigPAFactorAST(DesignatorAST des, ActParsAST par)
		{
			pars=par;
			desig=des;
		}
		
		public override object visit(Visitor v,object arg){
			return v.VisitDesigPAFactorAST(this,arg);
		}
	}
}
