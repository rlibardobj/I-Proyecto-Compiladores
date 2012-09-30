/*
 * Created by SharpDevelop.
 * User: HMSS
 * Date: 23/09/2012
 * Time: 09:54 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace ASintactico
{
	/// <summary>
	/// Description of IDAddonAST.
	/// </summary>
	public class IDAddonAST:DesigAddonAST
	{
		TerminalesAST ident;
		public IDAddonAST(TerminalesAST id)
		{
			ident=id;
		}
		
		public override object visit(Visitor v,object arg){
			return v.VisitIDAddon(this,arg);
		}
	}
}
