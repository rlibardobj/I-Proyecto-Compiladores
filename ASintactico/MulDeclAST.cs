/*
 * Created by SharpDevelop.
 * User: rlibardobj
 * Date: 23/09/2012
 * Time: 08:47 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace ASintactico
{
	/// <summary>
	/// Description of MulDeclAST.
	/// </summary>
	public class MulDeclAST : DeclarationsAST
	{
		DeclarationsAST declaracion;
		DeclarationsAST declaraciones;
		
		public MulDeclAST(DeclarationsAST decl,DeclarationsAST decls)
		{
			declaracion=decl;
			declaraciones=decls;
		}
	}
}
