/*
 * Created by SharpDevelop.
 * User: HMSS
 * Date: 23/09/2012
 * Time: 09:53 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace ASintactico
{
	/// <summary>
	/// Description of MulDesigAddonAST.
	/// </summary>
	public class MulDesigAddonAST:DesigAddonsAST
	{
		DesigAddonsAST addon,addons;
		public MulDesigAddonAST(DesigAddonsAST addo, DesigAddonsAST addos)
		{
			addon=addo;
			addons=addos;
		}
		
		public override object visit(Visitor v,object arg){
			return v.VisitMulDesigAddonAST(this,arg);
		}
	}
}
