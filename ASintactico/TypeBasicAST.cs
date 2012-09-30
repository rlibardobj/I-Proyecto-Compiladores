/*
 * Created by SharpDevelop.
 * User: rlibardobj
 * Date: 23/09/2012
 * Time: 10:38 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace ASintactico
{
	/// <summary>
	/// Description of TypeBasicAST.
	/// </summary>
	public class TypeBasicAST : TypeAST
	{
		TerminalesAST ident;
		public TypeBasicAST(TerminalesAST id)
		{
			ident=id;
		}
		
		public override object visit(Visitor v,object arg){
			return v.VisitTypeBasicAST(this,arg);
		}
	}
}
