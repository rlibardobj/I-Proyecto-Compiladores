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
	{   //Program
		object VisitProgramBasic(ProgramBasic v,object arg);
		object VisitProgramD(ProgramDAST v,object arg);
		object VisitProgramDM(ProgramDMAST v,object arg);
		object VisitProgramM(ProgramMAST v,object arg);
		//Declarations
		object VisitUnDeclAST(UnDeclAST v,object arg);
		object VisitMulDeclAST(MulDeclAST v,object arg);
	    //Declaration
	    object VisitConstDeclAST(ConstDeclAST v,object arg);
	    object VisitClassDeclVAST(ClassDeclVAST v,object arg);
	    object VisitClassDeclBasicAST(ClassDeclBasicAST v,object arg);
	    object VisitDeclMulIDAST(VarDeclMulIDAST v,object arg);
	    object VisitDeclUnIDAST(VarDeclUnIDAST v,object arg);
	    object VisitMethodDeclFAST(MethodDeclFAST v,object arg);
	    object VisitMethodDeclFMAST(MethodDeclFMAST v,object arg);
	    object VisitMethodDeclMAST(MethodDeclMAST v,object arg);
	    object VisitMethodDeclBasicAST(MethodDeclBasicAST v,object arg);
	    // no veo MulIdentV y UnIdentV
	    //FormPars
	    object VisitUnFormParsAST(UnFormParsAST v,object arg);
	    object VisitMulFormParsAST(MulFormParsAST v,object arg);
	    //Type
	    object VisitTypeCAST(TypeCAST v,object arg);
	    object VisitTypeBasicAST(TypeBasicAST v,object arg);
	    //Block
	    object VisitBlockSAST(BlockSAST v,object arg);
	    object VisitBlockBasicAST(BlockBasicAST v,object arg);
	    //Statements
	    object VisitUnStatementAST(UnStatementAST v,object arg);
	    object VisitMulStatementAST(MulStatementAST v,object arg);
	    //Statement
	    object VisitDesigminusStatAST(DesigminusStatAST v,object arg);
	    object VisitDesigplusStatAST(DesigplusStatAST v,object arg);
	    object VisitReturnEStatAST(ReturnEStatAST v,object arg);
	    object VisitReturnBasicStatAST(ReturnBasicStatAST v,object arg);
	    object VisitDesigEStatAST(DesigEStatAST v,object arg);
	    object VisitDesigPStatAST(DesigPStatAST v,object arg);
	    object VisitDesigPAStatAST(DesigPAStatAST v,object arg);
	    object VisitIfElseStatAST(IfElseStatAST v,object arg);
	    object VisitIfStatAST(IfStatAST v,object arg);
	    object VisitReadStatAST(ReadStatAST v,object arg);
	    object VisitWriteStatAST(WriteStatAST v,object arg);
	    object VisitWriteNStatAST(WriteNStatAST v,object arg);
	    object VisitWhileStatAST(WhileStatAST v,object arg);
	    object VisitForEStatAST(ForEStatAST v,object arg);
	    object VisitForEEStatAST(ForEEStatAST v,object arg);
	    object VisitForBasicStatAST(ForBasicStatAST v,object arg);
	    object VisitPyComaStatAST(PyComaStatAST v,object arg);
	    object VisitBreakStatAST(BreakStatAST v,object arg);
	    object VisitBlockStatAST(BlockStatAST v,object arg);
	    //CondTerm
	    object VisitUnCondFactAST(UnCondFactAST v,object arg);
	    object VisitMulCondFactAST(MulCondFactAST v,object arg);
	    //Conditions
	    object VisitUnCondTermAST(UnCondTermAST v,object arg);
	    object VisitMulCondTermAST(MulCondTermAST v,object arg);
	    //ActPars
	    object VisitUnExprAST(UnExprAST v,object arg);
	    object VisitMulExprAST(MulExprAST v,object arg);
	    //Expr
	    object VisitMulTermMExprAST(MulTermMExprAST v,object arg);
	    object VisitMulTermExprAST(MulTermExprAST v,object arg);
	    object VisitUnTermExprAST(UnTermExprAST v,object arg);
	    object VisitUnTermMExprAST(UnTermMExprAST v,object arg);
	    //Term
	    object VisitUnFactorAST(UnFactorAST v,object arg);
	    object VisitMulFactorAST(MulFactorAST v,object arg);
	    //Factor
	    object VisitCharConstFactorAST(CharConstFactorAST v,object arg);
	    object VisitNumFactorAST(NumFactorAST v,object arg);
	    object VisitDesigPFactorAST(DesigPFactorAST v,object arg);
	    object VisitDesigPAFactorAST(DesigPAFactorAST v,object arg);
	    object VisitDesigBasicFactorAST(DesigBasicFactorAST v,object arg);
	    object VisitExprFactorAST(ExprFactorAST v,object arg);
	    object VisitNewEFactorAST(NewEFactorAST v,object arg);
	    object VisitNewBasicFactorAST(NewBasicFactorAST v,object arg);
	    object VisitBoolFactorAST(BoolFactorAST v,object arg);
	    //Designator
	    object VisitDesigComplexAST(DesigComplexAST v,object arg);
	    object VisitDesigBasicAST(DesigBasicAST v,object arg);
	    //DesigAddons
	    object VisitMulDesigAddonAST(MulDesigAddonAST v,object arg);
	    object VisitUnDesigAddonAST(UnDesigAddonAST v,object arg);
	    //DesigAddon
	    object VisitExprAddonAST(ExprAddonAST v,object arg);
	    object VisitIDAddon(IDAddonAST v,object arg);
	
	
	}
}
