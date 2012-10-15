/*
 * Created by SharpDevelop.
 * User: HMSS
 * Date: 23/09/2012
 * Time: 09:50 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace ASintactico
{
	/// <summary>
	/// Description of DesigBasicAST.
	/// </summary>
	public class DesigBasicAST:DesignatorAST
	{
		public TerminalesAST ident;
		
		public DesigBasicAST(TerminalesAST id)
		{
			ident=id;
		}
		
		public override object visit(Visitor v,object arg){
			return v.VisitDesigBasicAST(this,arg);
		}
	}
}
