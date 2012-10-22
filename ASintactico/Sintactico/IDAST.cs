/*
 * Created by SharpDevelop.
 * User: rlibardobj
 * Date: 29/09/2012
 * Time: 04:49 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace ASintactico
{
	/// <summary>
	/// Description of IDAST.
	/// </summary>
	public class IDAST : TerminalesAST
	{
		public Token ident;
		
		public IDAST(Token id)
		{
			ident=id;
		}
		public override object visit(Visitor v,object arg){
			return v.VisitIDAST(this,arg);
		}
	}
}
