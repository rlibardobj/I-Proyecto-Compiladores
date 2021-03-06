﻿/*
 * Created by SharpDevelop.
 * User: rlibardobj
 * Date: 23/09/2012
 * Time: 10:25 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace ASintactico
{
	/// <summary>
	/// Description of MulIDVarDeclAST.
	/// </summary>
	public class VarDeclMulIDAST : DeclarationAST
	{
		public DeclarationAST identificador;
		public DeclarationAST identificadores;
		
		public VarDeclMulIDAST(DeclarationAST ids,DeclarationAST id)
		{
			identificador=id;
			identificadores=ids;
		}
		
		public override object visit(Visitor v,object arg){
			return v.VisitDeclMulIDAST(this,arg);
		}
	}
}
