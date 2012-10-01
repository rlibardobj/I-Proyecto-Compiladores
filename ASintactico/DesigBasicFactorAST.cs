/*
 * Created by SharpDevelop.
 * User: HMSS
 * Date: 23/09/2012
 * Time: 09:39 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace ASintactico
{
	/// <summary>
	/// Description of DesigBasicFactorAST.
	/// </summary>
	public class DesigBasicFactorAST:FactorAST
	{
		public DesignatorAST desig;
		
		public DesigBasicFactorAST(DesignatorAST des)
		{
			desig=des;
		}
		
		public override object visit(Visitor v,object arg){
			return v.VisitDesigBasicFactorAST(this,arg);
		}
	}
}
