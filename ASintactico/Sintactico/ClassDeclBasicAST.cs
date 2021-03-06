﻿/*
 * Created by SharpDevelop.
 * User: rlibardobj
 * Date: 23/09/2012
 * Time: 10:26 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace ASintactico
{
	/// <summary>
	/// Description of ClassDeclBasicAST.
	/// </summary>
	public class ClassDeclBasicAST : DeclarationAST
	{
		public IDAST ident;
		
		public ClassDeclBasicAST(IDAST id)
		{
			ident=id;
		}
		
		public override object visit(Visitor v,object arg){
			return v.VisitClassDeclBasicAST(this,arg);
		}
	}
}
