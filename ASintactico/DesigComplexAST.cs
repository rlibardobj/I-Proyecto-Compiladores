/*
 * Created by SharpDevelop.
 * User: HMSS
 * Date: 23/09/2012
 * Time: 09:51 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace ASintactico
{
	/// <summary>
	/// Description of DesigComplexAST.
	/// </summary>
	public class DesigComplexAST:DesignatorAST
	{
		IDAST ident;
		DesigAddonsAST addon;
		public DesigComplexAST(DesigAddonsAST addo, IDAST id)
		{
			ident=id;
			addon=addo;
		}
		
		public override object visit(Visitor v,object arg){
			return v.VisitDesigComplexAST(this,arg);
		}
	}
}
