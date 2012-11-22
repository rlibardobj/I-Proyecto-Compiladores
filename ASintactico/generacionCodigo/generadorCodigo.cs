/*
 * Creado por SharpDevelop.
 * Usuario: rlibardobj
 * Fecha: 07/11/2012
 * Hora: 01:22 p.m.
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Reflection;
using System.Reflection.Emit;

namespace ASintactico.generacionCodigo
{
	/// <summary>
	/// Description of generadorCodigo.
	/// </summary>
	public class generadorCodigo:Visitor
	{
		
		ModuleBuilder modulo;
		List<Type> parametros;
		List<LocalBuilder> variablesLocales;
		List<TypeBuilder> clases;
		List<FieldBuilder> variables;
		List<MethodBuilder> metodos;
		
		public generadorCodigo()
		{
			this.parametros=new List<Type>();
			this.variablesLocales=new List<LocalBuilder>();
			this.variables=new List<FieldBuilder>();
			this.clases=new List<TypeBuilder>();
			this.metodos=new List<MethodBuilder>();
		}
		
		public Type iniciarConstruccion(AST arbol)
		{
			return (Type)arbol.visit(this,null);
		}
		
		public object VisitProgramBasicAST(ProgramBasic v,object arg)
		{
			return null;
		}
		
		public object VisitProgramDAST(ProgramDAST v,object arg)
		{
			Type pointType = null;

			AppDomain currentDom = Thread.GetDomain();

			string asmFileName = "compilador.exe";

			AssemblyName myAsmName = new AssemblyName();
			myAsmName.Name = "Ensamblaje";

			AssemblyBuilder myAsmBldr = currentDom.DefineDynamicAssembly(
				myAsmName,
				AssemblyBuilderAccess.RunAndSave);

			modulo = myAsmBldr.DefineDynamicModule(asmFileName,
			                                       asmFileName);

			TypeBuilder act = modulo.DefineType(v.ident.ident.value);
			Type objType = Type.GetType("System.Object");
            ConstructorInfo objCtor = objType.GetConstructor(new Type[0]);

            ConstructorBuilder pointCtor = act.DefineConstructor(
                                       MethodAttributes.Public,
                                      CallingConventions.Standard,
                                      null);
            
            ILGenerator ctorIL = pointCtor.GetILGenerator();
            ctorIL.Emit(OpCodes.Ldarg_0);
            ctorIL.Emit(OpCodes.Call, objCtor);
            ctorIL.Emit(OpCodes.Ret);

			v.declaraciones.visit(this,act);
			

			pointType = act.CreateType();

			Console.WriteLine("Tipo Completado");
			
			myAsmBldr.Save(asmFileName);

			Console.WriteLine("Emsamblaje guardado con el nombre '{0}'.", asmFileName);

			return pointType;
		}
		
		public object VisitProgramDMAST(ProgramDMAST v,object arg)
		{
			Type pointType = null;

			AppDomain currentDom = Thread.GetDomain();

			string asmFileName = "compilador.exe";

			AssemblyName myAsmName = new AssemblyName();
			myAsmName.Name = "Ensamblaje";

			AssemblyBuilder myAsmBldr = currentDom.DefineDynamicAssembly(
				myAsmName,
				AssemblyBuilderAccess.RunAndSave);

			modulo = myAsmBldr.DefineDynamicModule(asmFileName,
			                                       asmFileName);

			TypeBuilder act = modulo.DefineType(v.ident.ident.value);
			Type objType = Type.GetType("System.Object");
            ConstructorInfo objCtor = objType.GetConstructor(new Type[0]);

            ConstructorBuilder pointCtor = act.DefineConstructor(
                                       MethodAttributes.Public,
                                      CallingConventions.Standard,
                                      null);
            
            ILGenerator ctorIL = pointCtor.GetILGenerator();
            ctorIL.Emit(OpCodes.Ldarg_0);
            ctorIL.Emit(OpCodes.Call, objCtor);
            ctorIL.Emit(OpCodes.Ret);

			v.declaraciones.visit(this,act);
			MethodBuilder puntoEntrada=(MethodBuilder)v.metodos.visit(this,act);
			myAsmBldr.SetEntryPoint(puntoEntrada);
			
			pointType = act.CreateType();

			Console.WriteLine("Tipo Completado");
			
			myAsmBldr.Save(asmFileName);

			Console.WriteLine("Emsamblaje guardado con el nombre '{0}'.", asmFileName);

			return pointType;
		}
		
		public object VisitProgramMAST(ProgramMAST v,object arg)
		{
			Type pointType = null;

			AppDomain currentDom = Thread.GetDomain();

			string asmFileName = "compilador.exe";

			AssemblyName myAsmName = new AssemblyName();
			myAsmName.Name = "Ensamblaje";

			AssemblyBuilder myAsmBldr = currentDom.DefineDynamicAssembly(
				myAsmName,
				AssemblyBuilderAccess.RunAndSave);

			modulo = myAsmBldr.DefineDynamicModule(asmFileName,asmFileName);

			TypeBuilder act = modulo.DefineType(v.ident.ident.value);
			Type objType = Type.GetType("System.Object");
            ConstructorInfo objCtor = objType.GetConstructor(new Type[0]);

            ConstructorBuilder pointCtor = act.DefineConstructor(
                                       MethodAttributes.Public,
                                      CallingConventions.Standard,
                                      null);
            
            ILGenerator ctorIL = pointCtor.GetILGenerator();
            ctorIL.Emit(OpCodes.Ldarg_0);
            ctorIL.Emit(OpCodes.Call, objCtor);
            ctorIL.Emit(OpCodes.Ret);

            MethodBuilder puntoEntrada=(MethodBuilder)v.metodos.visit(this,act);
			myAsmBldr.SetEntryPoint(puntoEntrada);
			
			pointType = act.CreateType();

			Console.WriteLine("Tipo Completado");
			
			myAsmBldr.Save(asmFileName);

			Console.WriteLine("Emsamblaje guardado con el nombre '{0}'.", asmFileName);

			return pointType;
		}
		
		
		//DeclarationsAST
		
		public object VisitUnDeclAST(UnDeclAST v,object arg)
		{
			return v.declaracion.visit(this,arg);
		}
		
		public object VisitMulDeclAST(MulDeclAST v,object arg)
		{
			object variable=v.declaracion.visit(this,arg),variable2=v.declaraciones.visit(this,arg);
			if (variable!=null)
				return variable;
			else 
				return variable2;
			return null;
		}
		
		
		//DeclarationAST
		
		public object VisitConstDeclAST(ConstDeclAST v,object arg)
		{
			string stringtipo=(string)v.tipo.visit(this,arg);
			Type tipo=this.tipo(stringtipo,arg);
			if (arg.GetType().Name.Equals("TypeBuilder")){
				TypeBuilder act=(TypeBuilder)arg;
				variables.Add(act.DefineField(v.value.value,tipo,FieldAttributes.Literal));
			}
			else
			{
				ILGenerator act=(ILGenerator)arg;
				variablesLocales.Add(act.DeclareLocal(tipo));
			}
			return null;
		}
		
		public object VisitClassDeclVAST(ClassDeclVAST v,object arg)
		{
			TypeBuilder tipo=((TypeBuilder)arg).DefineNestedType(v.ident.ident.value);
			clases.Add(tipo);
			v.declaraciones.visit(this,tipo);
			return null;
		}
		
		public object VisitClassDeclBasicAST(ClassDeclBasicAST v,object arg)
		{
			clases.Add(((TypeBuilder)arg).DefineNestedType(v.ident.ident.value));
			return null;
		}
		
		public object VisitDeclMulIDAST(VarDeclMulIDAST v,object arg)
		{
			v.identificador.visit(this,arg);
			v.identificadores.visit(this,arg);
			return null;
		}
		
		public object VisitDeclUnIDAST(VarDeclUnIDAST v,object arg)
		{
			string stringtipo=(string)v.tipo.visit(this,arg);
			Type tipo=this.tipo(stringtipo,arg);
			if (arg.GetType().Name.Equals("TypeBuilder"))
			{
				TypeBuilder act=(TypeBuilder)arg;
				FieldBuilder variable=act.DefineField(v.identificador.value,tipo,FieldAttributes.Public|
				                              FieldAttributes.Static);
				variables.Add(variable);
			}
			else
			{
				ILGenerator act=(ILGenerator)arg;
				LocalBuilder variable=act.DeclareLocal(tipo);
				variablesLocales.Add(variable);
			}
			return null;
		}
		//parametros(F)
		public object VisitMethodDeclFAST(MethodDeclFAST v,object arg)
		{
			TypeBuilder act=(TypeBuilder)arg;
			string stringtipo=(string)v.tipo.visit(this,arg);
			Type tipo=this.tipo(stringtipo,arg);
			v.parametros.visit(this,arg);
			MethodBuilder metodo=act.DefineMethod(v.ident.value,MethodAttributes.Public|MethodAttributes.Static,tipo,parametros.ToArray());
			metodos.Add(metodo);
			parametros.Clear();
			metodo.InitLocals=true;
			ILGenerator constructorMetodo=metodo.GetILGenerator();
			v.bloque.visit(this,constructorMetodo);
			if (v.ident.value.Equals("main")){
				return metodo;
			}
			else return null;
		}
		//parametros(F) y declariones (M)
		public object VisitMethodDeclFMAST(MethodDeclFMAST v,object arg)
		{
			TypeBuilder act=(TypeBuilder)arg;
			string stringtipo=(string)v.tipo.visit(this,arg);
			Type tipo=this.tipo(stringtipo,arg);
			v.parametros.visit(this,arg);
			MethodBuilder metodo=act.DefineMethod(v.ident.value,MethodAttributes.Public|MethodAttributes.Static,tipo,parametros.ToArray());
			metodos.Add(metodo);
			parametros.Clear();
			metodo.InitLocals=true;
			ILGenerator constructorMetodo=metodo.GetILGenerator();
			v.declaraciones.visit(this,constructorMetodo);
			v.bloque.visit(this,constructorMetodo);
			if (v.ident.value.Equals("main")){
				return metodo;
			}
			else return null;
		}
		//declariones (M)
		public object VisitMethodDeclMAST(MethodDeclMAST v,object arg)
		{
			TypeBuilder act=(TypeBuilder)arg;
			string stringtipo=(string)v.tipo.visit(this,arg);
			Type tipo=this.tipo(stringtipo,arg);
			MethodBuilder metodo=act.DefineMethod(v.ident.value,MethodAttributes.Public|MethodAttributes.Static,tipo,null);
			metodos.Add(metodo);
			metodo.InitLocals=true;
			ILGenerator constructorMetodo=metodo.GetILGenerator();
			v.declaraciones.visit(this,constructorMetodo);
			v.bloque.visit(this,constructorMetodo);
			if (v.ident.value.Equals("main")){
				return metodo;
			}
			else return null;
		}
		
		public object VisitMethodDeclBasicAST(MethodDeclBasicAST v,object arg)
		{
			TypeBuilder act=(TypeBuilder)arg;
			string stringtipo=(string)v.tipo.visit(this,arg);
			Type tipo=this.tipo(stringtipo,arg);
			MethodBuilder metodo=act.DefineMethod(v.ident.value,MethodAttributes.Public|MethodAttributes.Static,tipo,null);
			metodos.Add(metodo);
			metodo.InitLocals=true;
			ILGenerator constructorMetodo=metodo.GetILGenerator();
			v.bloque.visit(this,constructorMetodo);
			if (v.ident.value.Equals("main")){
				return metodo;
			}
			else return null;
		}
		
		
		//TypeAST
		//Type corchetes
		public object VisitTypeCAST(TypeCAST v,object arg)
		{
			return v.ident.value;
		}
		
		public object VisitTypeBasicAST(TypeBasicAST v,object arg)
		{
			return v.ident.value;
		}
		
		
		//BlockAST
		//block statement
		public object VisitBlockSAST(BlockSAST v,object arg)
		{
			v.statement.visit(this,arg);
			return null;
		}
		
		public object VisitBlockBasicAST(BlockBasicAST v,object arg)
		{
			return null;
		}
		//vacio
		public object VisitDesigBasicFactorAST(DesigBasicFactorAST v,object arg)
		{
			ILGenerator generador=(ILGenerator)arg;
			FieldBuilder variable=(FieldBuilder)v.desig.visit(this,arg);
			generador.Emit(OpCodes.Ldsfld,variable);
			return null;
		}
		//Expresiones entre parentesis
		public object VisitExprFactorAST(ExprFactorAST v,object arg)
		{
			v.expresion.visit(this, arg);
			return null;
		}
		//New ID expresion
		public object VisitNewEFactorAST(NewEFactorAST v,object arg)
		{
			return null;
		}
		//new id sin expr
		public object VisitNewBasicFactorAST(NewBasicFactorAST v,object arg)
		{
			return null;
		}
		//Bool
		public object VisitBoolFactorAST(BoolFactorAST v,object arg)
		{
			return null;
		}
		
		
		
		//----------------------------------------------------------------------------------------
		
		//Designator
		public object VisitDesigComplexAST(DesigComplexAST v,object arg)
		{
			return null;
		}
		
		public object VisitDesigBasicAST(DesigBasicAST v,object arg)
		{
			foreach (FieldBuilder temp in variables)
			{
				if (temp.Name==v.ident.ident.value)
					return temp;
			}
			foreach (MethodBuilder temp in metodos)
			{
				if (temp.Name==v.ident.ident.value)
					return temp;
			}
			foreach (TypeBuilder temp in clases)
			{
				if (temp.Name==v.ident.ident.value)
					return temp;
			}
			foreach (LocalBuilder temp in variablesLocales)
			{
				return temp;
			}
			return null;
		}
		
		//----------------------------------------------------------------------------------------
		
		//DesigAddons
		public object VisitMulDesigAddonAST(MulDesigAddonAST v,object arg)
		{
			return null;
		}
		
		public object VisitUnDesigAddonAST(UnDesigAddonAST v,object arg)
		{
			return null;
		}
		
		//----------------------------------------------------------------------------------------
		
		public object VisitExprAddonAST(ExprAddonAST v,object arg)
		{
			return null;
		}
		
		public object VisitIDAddon(IDAddonAST v,object arg)
		{
			return null;
		}
		
		public object VisitUnCondFactAST(UnCondFactAST v,object arg)
		{
			v.condfact.visit(this,arg);
			return null;
		}
		
		public object VisitMulCondFactAST(MulCondFactAST v,object arg)
		{
			ILGenerator generador=(ILGenerator)arg;
			v.condfact.visit(this,arg);
			v.condfacts.visit(this,arg);
			generador.Emit(OpCodes.Or);
			return null;
		}
		
		//----------------------------------------------------------------------------------------
		
		//CondFact
		public object VisitConditionAST(ConditionAST v,object arg)
		{
			ILGenerator generador=(ILGenerator)arg;
			v.expr.visit(this,arg);
			v.expr1.visit(this,arg);
			switch (v.relop.value.sym){
					case 20:{
						generador.Emit(OpCodes.Ceq);
						break;}
					case 22:{
						generador.Emit(OpCodes.Cgt);
						break;}
					case 23:{
						generador.Emit(OpCodes.Clt);
						break;}
					case 24:{ //2>=1
						generador.Emit(OpCodes.Clt); // 0 a la pila
						generador.Emit(OpCodes.Ldc_I4_0); //meto 0 a la pila (0 es un falso)
						generador.Emit(OpCodes.Ceq); //comparo y si son iguales mete 1 a la pila
						break;}
					case 25:{
						generador.Emit(OpCodes.Cgt);
						generador.Emit(OpCodes.Ldc_I4_0);
						generador.Emit(OpCodes.Ceq);
						break;}
			}
			return null;
		}

		
		//----------------------------------------------------------------------------------------
		
		//Conditions
		public object VisitUnCondTermAST(UnCondTermAST v,object arg)
		{
			v.condterm.visit(this,arg);
			return null;
		}
		
		public object VisitMulCondTermAST(MulCondTermAST v,object arg)
		{
			ILGenerator generador=(ILGenerator)arg;
			v.condterm.visit(this,arg);
			v.condterms.visit(this,arg);
			generador.Emit(OpCodes.And);
			return null;
		}
		
		//----------------------------------------------------------------------------------------
		
		//ActPars
		public object VisitUnExprAST(UnExprAST v,object arg)
		{
			v.expresion.visit(this,arg);
			return null;
		}
		public object VisitMulExprAST(MulExprAST v,object arg)
		{
			v.expresion.visit(this,arg);
			v.expresiones.visit(this,arg);
			return null;
		}
		
		//----------------------------------------------------------------------------------------
		
		//Expr
		public object VisitMulTermMExprAST(MulTermMExprAST v,object arg)
		{
			ILGenerator generador=(ILGenerator)arg;
			v.term.visit(this,arg);
			v.terms.visit(this,arg);
			switch (v.operador.value){
					case "+": {generador.Emit(OpCodes.Add_Ovf);
					break;}
					case "-": {generador.Emit(OpCodes.Sub_Ovf);
					break;}
					default : {break;}
					
			}
			return null;
		}
		
		public object VisitMulTermExprAST(MulTermExprAST v,object arg)
		{
			ILGenerator generador=(ILGenerator)arg;
			v.term.visit(this,arg);
			v.terms.visit(this,arg);
			switch (v.operador.value){
					case "+": {generador.Emit(OpCodes.Add_Ovf);
					break;}
					case "-": {generador.Emit(OpCodes.Sub_Ovf);
					break;}
					default : {break;}
					
			}
			return null;
		}
		
		public object VisitUnTermExprAST(UnTermExprAST v,object arg)
		{
			v.term.visit(this,arg);
			return null;
		}
		
		public object VisitUnTermMExprAST(UnTermMExprAST v,object arg)
		{
			v.term.visit(this,arg);
			return null;
		}
		
		//----------------------------------------------------------------------------------------
		
		//Term
		public object VisitUnFactorAST(UnFactorAST v,object arg)
		{
			v.factor.visit(this,arg);
			return null;
		}
		
		public object VisitMulFactorAST(MulFactorAST v,object arg)
		{
			ILGenerator generador=(ILGenerator)arg;
			v.fac.visit(this,arg);
			v.facs.visit(this,arg);
			switch (v.operador.value){
					case "*": {generador.Emit(OpCodes.Mul_Ovf);
					break;}
					case "/": {generador.Emit(OpCodes.Div);
					break;}
					case "%": {generador.Emit(OpCodes.Rem);
					break;}
					default : {break;}
					
			}
			return null;
		}
		
		//----------------------------------------------------------------------------------------
		
		//Factor
		public object VisitCharConstFactorAST(CharConstFactorAST v,object arg)
		{
			ILGenerator generador=(ILGenerator)arg;
			generador.Emit(OpCodes.Ldc_I4,v.charconst.car.value);
			return null;
		}
		
		public object VisitNumFactorAST(NumFactorAST v,object arg)
		{
			ILGenerator generador=(ILGenerator)arg;
			generador.Emit(OpCodes.Ldc_I4,int.Parse(v.num.num.value));
			return null;
		}
		
		public object VisitDesigPFactorAST(DesigPFactorAST v,object arg)
		{
			ILGenerator generador=(ILGenerator)arg;
			generador.EmitCall(OpCodes.Call,(MethodBuilder)v.desig.visit(this,arg),null);
			return null;
		}
		
		public object VisitDesigPAFactorAST(DesigPAFactorAST v,object arg)
		{
			ILGenerator generador=(ILGenerator)arg;
			v.pars.visit(this,arg);
			generador.EmitCall(OpCodes.Call,(MethodBuilder)v.desig.visit(this,arg),null);
			return null;
		}
		
		public object VisitUnStatementAST(UnStatementAST v,object arg)
		{
			v.statement.visit(this,arg);
			return null;
		}
		
		public object VisitMulStatementAST(MulStatementAST v,object arg)
		{
			v.statements.visit(this,arg);
			v.statement.visit(this,arg);
			return null;
		}
		
		//----------------------------------------------------------------------------------------
		
		//Statement
		public object VisitDesigminusStatAST(DesigminusStatAST v,object arg)
		{
			ILGenerator generador=(ILGenerator)arg;
			object tipoVariable=v.designator.visit(this,1);
			if(tipoVariable.GetType().Name.Equals("FieldBuilder"))
			{
				generador.Emit(OpCodes.Ldc_I4_1);
				generador.Emit(OpCodes.Ldsfld,(FieldBuilder)tipoVariable);
				generador.Emit(OpCodes.Add);
				generador.Emit(OpCodes.Stsfld,(FieldBuilder)tipoVariable);
			}
			else
			{
				generador.Emit(OpCodes.Ldc_I4_1);
				generador.Emit(OpCodes.Ldsfld,(LocalBuilder)tipoVariable);
				generador.Emit(OpCodes.Add);
				generador.Emit(OpCodes.Stsfld,(LocalBuilder)tipoVariable);
			}
			return null;
		}
		
		public object VisitDesigplusStatAST(DesigplusStatAST v,object arg)
		{
			ILGenerator generador=(ILGenerator)arg;
			object tipoVariable=v.designator.visit(this,arg);
			if(tipoVariable.GetType().Name.Equals("FieldBuilder"))
			{
				generador.Emit(OpCodes.Ldc_I4_1);
				generador.Emit(OpCodes.Ldsfld,(FieldBuilder)tipoVariable);
				generador.Emit(OpCodes.Add);
				generador.Emit(OpCodes.Stsfld,(FieldBuilder)tipoVariable);
			}
			else
			{
				generador.Emit(OpCodes.Ldc_I4_1);
				generador.Emit(OpCodes.Ldsfld,(LocalBuilder)tipoVariable);
				generador.Emit(OpCodes.Add);
				generador.Emit(OpCodes.Stsfld,(LocalBuilder)tipoVariable);
			}
			return null;
		}
		
		public object VisitReturnEStatAST(ReturnEStatAST v,object arg)
		{
			ILGenerator generador=(ILGenerator)arg;
			v.expresion.visit(this,arg);
			generador.Emit(OpCodes.Ret);
			return false;
		}
		
		public object VisitReturnBasicStatAST(ReturnBasicStatAST v,object arg)
		{
			ILGenerator generador=(ILGenerator)arg;
			generador.Emit(OpCodes.Ret);
			return false;
		}
		
		public object VisitDesigEStatAST(DesigEStatAST v,object arg)
		{
			ILGenerator generador=(ILGenerator)arg;
			v.expresion.visit(this,arg);
			FieldBuilder variable=(FieldBuilder)v.designator.visit(this,arg);
			generador.Emit(OpCodes.Stsfld,variable);
			return null;
		}
		
		public object VisitDesigPStatAST(DesigPStatAST v,object arg)
		{
			ILGenerator generador=(ILGenerator)arg;
			MethodBuilder metodo=(MethodBuilder)v.designator.visit(this,arg);
			generador.EmitCall(OpCodes.Call,metodo,null);
			return null;
		}
		
		public object VisitDesigPAStatAST(DesigPAStatAST v,object arg)
		{
			ILGenerator generador=(ILGenerator)arg;
			v.expresion.visit(this,arg);
			MethodBuilder metodo=(MethodBuilder)v.designator.visit(this,arg);
			generador.EmitCall(OpCodes.Call,metodo,null);
			return null;
		}
		
		public object VisitIfElseStatAST(IfElseStatAST v,object arg)
		{
			ILGenerator generador=(ILGenerator)arg;
			Label etiquetaElse=generador.DefineLabel(),etiquetaContinuar=generador.DefineLabel();
			v.condicion.visit(this,arg);
			generador.Emit(OpCodes.Ldc_I4_0);
			generador.Emit(OpCodes.Beq,etiquetaElse);
			v.ifstatement.visit(this,arg);
			generador.Emit(OpCodes.Br,etiquetaContinuar);
			generador.MarkLabel(etiquetaElse);
			v.elsestatement.visit(this,arg);
			generador.MarkLabel(etiquetaContinuar);
			return null;
		}
		
		public object VisitIfStatAST(IfStatAST v,object arg)
		{
			ILGenerator generador=(ILGenerator)arg;
			Label etiquetaFalso=generador.DefineLabel();
			v.condicion.visit(this,arg);
			generador.Emit(OpCodes.Ldc_I4_0);
			generador.Emit(OpCodes.Beq,etiquetaFalso);
			v.statement.visit(this,arg);
			generador.MarkLabel(etiquetaFalso);
			return null;
		}
		
		public object VisitReadStatAST(ReadStatAST v,object arg)
		{
			ILGenerator generador=(ILGenerator)arg;
			MethodInfo read = typeof(Console).GetMethod("ReadKey",new Type[0]);
			/*object variable=v.designator.visit(this,arg);
			if (variable.GetType().Name=="FieldBuilder"){
				generador.EmitCall(OpCodes.Call,read,null);
				generador.Emit(OpCodes.Stsfld,(FieldBuilder)variable);
			}
			else
			{
				generador.EmitCall(OpCodes.Call,read,null);
				generador.Emit(OpCodes.Stsfld,(LocalBuilder)variable);
			}*/
			generador.EmitCall(OpCodes.Call,read,null);
			return null;
		}
		
		public object VisitWriteStatAST(WriteStatAST v,object arg)
		{
			ILGenerator generador=(ILGenerator)arg;
			v.expresion.visit(this,arg);
			MethodInfo write = typeof(Console).GetMethod("WriteLine",new Type[0]);
			generador.EmitCall(OpCodes.Call,write,null);
			return null;
		}
		
		public object VisitWriteNStatAST(WriteNStatAST v,object arg) //Para después
		{
			return null;
		}
		
		public object VisitWhileStatAST(WhileStatAST v,object arg)
		{
			ILGenerator generador=(ILGenerator)arg;
			Label etiquetaEntrada=generador.DefineLabel(),etiquetaSalida=generador.DefineLabel();
			generador.MarkLabel(etiquetaEntrada);
			v.condicion.visit(this,arg);
			generador.Emit(OpCodes.Ldc_I4_0);
			generador.Emit(OpCodes.Beq,etiquetaSalida);
			v.statement.visit(this,arg);
			generador.Emit(OpCodes.Br,etiquetaEntrada);
			generador.MarkLabel(etiquetaSalida);
			return null;
		}
		
		public object VisitForEStatAST(ForEStatAST v,object arg) //Para después
		{
			return null;
		}
		
		public object VisitForEEStatAST(ForEEStatAST v,object arg) //Después
		{
			return null;
		}
		
		public object VisitForBasicStatAST(ForBasicStatAST v,object arg) //Después
		{
			return null;
		}
		
		public object VisitPyComaStatAST(PyComaStatAST v,object arg) //Después
		{
			return null;
		}
		
		public object VisitBreakStatAST(BreakStatAST v,object arg)
		{
			ILGenerator generador=(ILGenerator)arg;
			generador.Emit(OpCodes.Break);
			return null;
		}
		
		public object VisitBlockStatAST(BlockStatAST v,object arg)
		{
			v.bloque.visit(this,arg);
			return null;
		}
		
		public object VisitIDAST(IDAST v,object arg) //No es necesaria
		{
			return null;
		}
		
		public object VisitBoolAST(BOOLAST v, object arg) //No es necesaria
		{
			return null;
		}
		
		public object VisitRELOPAST(RELOPAST v,object arg) //No es necesaria
		{
			return null;
		}
		
		public object VisitNUMAST(NUMAST v,object arg) //No es necesaria
		{
			return null;
		}
		
		public object VisitMULOPAST(MULOPAST v,object arg) //No es necesaria
		{
			return null;
		}
		
		public object VisitCHARAST(CHARAST v,object arg) //No es necesaria
		{
			return null;
		}
		
		public object VisitADDOPAST(ADDOPAST v,object arg) //No es necesaria
		{
			return null;
		}
		
		//----------------------------------------------------------------------------------------
		
		//FormPars
		public object VisitUnFormParsAST(UnFormParsAST v,object arg)
		{
			parametros.Add(tipo((string)v.tipo.visit(this,arg),arg));
			return null;
		}
		
		public object VisitMulFormParsAST(MulFormParsAST v,object arg)
		{
			v.parametro.visit(this,arg);
			return null;
		}

		public Type tipo(string type, object arg){
			switch(type){
					case "int": {return typeof(int);
						break;}
					case "char": {return typeof(char);
						break;}
					case "bool": {return typeof(bool);
						break;}
					case "void": {return typeof(void);
						break;}
				default:
					{	foreach (TypeBuilder i in clases)
						{
							if (i.Name.Equals(type))
								return i;
						}
						break;}
			}
			return null;
		}
	}
}
