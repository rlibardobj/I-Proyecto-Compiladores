/*
 * Created by SharpDevelop.
 * User: HMSS
 * Date: 23/09/2012
 * Time: 09:52 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace ASintactico
{
	/// <summary>
	/// Description of UnDesigAddon.
	/// </summary>
	public class UnDesigAddonAST:DesigAddonsAST
	{
		DesigAddonAST addon;
		public UnDesigAddonAST(DesigAddonAST addo)
		{
			addon=addo;
		}
		
		public override object visit(Visitor v,object arg){
			return v.VisitUnDesigAddonAST(this,arg);
		}
	}
}
