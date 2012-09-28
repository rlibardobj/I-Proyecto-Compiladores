/*
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
	/// Description of ClassDeclVAST.
	/// </summary>
	public class ClassDeclVAST : ClassDeclAST
	{
		DeclarationsAST declaraciones;
		public ClassDeclVAST(DeclarationsAST decls)
		{
			declaraciones=decls;
		}
	}
}
