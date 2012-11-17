/*
 * Created by SharpDevelop.
 * User: rlibardobj
 * Date: 23/09/2012
 * Time: 10:36 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace ASintactico
{
	/// <summary>
	/// Description of UnFormParsAST.
	/// </summary>
	public class UnFormParsAST : FormParsAST
	{
		public TypeAST tipo;
		public IDAST ident;
		
		public UnFormParsAST(IDAST id,TypeAST tip)
		{
			tipo=tip;
			ident=id;
		}
		
		public override object visit(Visitor v,object arg){
			return v.VisitUnFormParsAST(this,arg);
		}
	}
}
