/*
 * Created by SharpDevelop.
 * User: rlibardobj
 * Date: 23/09/2012
 * Time: 10:34 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace ASintactico
{
	/// <summary>
	/// Description of MethodDeclMAST.
	/// </summary>
	public class MethodDeclMAST : DeclarationAST
	{
		DeclarationsAST declaraciones;
		public MethodDeclMAST(DeclarationsAST decls)
		{
			declaraciones=decls;
		}
	}
}
