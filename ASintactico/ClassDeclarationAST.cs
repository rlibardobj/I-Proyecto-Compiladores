﻿/*
 * Created by SharpDevelop.
 * User: rlibardobj
 * Date: 23/09/2012
 * Time: 09:55 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace ASintactico
{
	/// <summary>
	/// Description of ClassDeclarationAST.
	/// </summary>
	public class ClassDeclarationAST : DeclarationAST
	{
		ClassDeclAST classdeclaration;
		public ClassDeclarationAST(ClassDeclAST declaracion)
		{
			classdeclaration=declaracion;
		}
	}
}
