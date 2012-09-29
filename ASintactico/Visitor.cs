/*
 * Created by SharpDevelop.
 * User: rlibardobj
 * Date: 27/09/2012
 * Time: 08:12 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using ASintactico;

namespace ASintactico
{
	/// <summary>
	/// Description of Visitor.
	/// </summary>
	public interface Visitor
	{
		object VisitProgramBasic(ProgramBasic v,object arg);
		object VisitProgramD(ProgramDAST v,object arg);
		object VisitProgramDM(ProgramDMAST v,object arg);
		object VisitProgramM(ProgramMAST v,object arg);
		object VisitUnDeclAST(UnDeclAST v,object arg);
	}
}
