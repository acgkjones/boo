using System;

namespace Boo.Ast
{
	public class DepthFirstTransformer : IAstTransformer
	{
		public bool Switch(Node node, out Node resultingNode)
		{			
			if (null != node)
			{			
				node.Switch(this, out resultingNode);
				return true;
			}
			resultingNode = node;
			return false;
		}
		
		public Node SwitchNode(Node node)
		{
			if (null != node)
			{
				Node resultingNode;
				node.Switch(this, out resultingNode);
				return resultingNode;
			}
			return null;
		}
		
		public Node Switch(Node node)
		{
			return SwitchNode(node);
		}
		
		public Expression Switch(Expression node)
		{
			return (Expression)SwitchNode(node);
		}
		
		public Statement Switch(Statement node)
		{
			return (Statement)SwitchNode(node);
		}
		
		public bool Switch(NodeCollection collection)
		{
			if (null != collection)
			{
				int removed = 0;
				
				Node[] nodes = collection.ToArray();
				for (int i=0; i<nodes.Length; ++i)
				{
					Node resultingNode;
					Node currentNode = nodes[i];
					currentNode.Switch(this, out resultingNode);
					if (currentNode != resultingNode)
					{
						int actualIndex = i-removed;
						if (null == resultingNode)
						{
							collection.RemoveAt(actualIndex);
						}
						else
						{
							collection.ReplaceAt(actualIndex, resultingNode);
						}
					}
				}
				return true;
			}
			return false;
		}
		
		public virtual void OnCompileUnit(CompileUnit node, ref CompileUnit resultingNode)
		{	
			if (EnterCompileUnit(node, ref resultingNode))
			{		
				Switch(node.Modules);
			}
			LeaveCompileUnit(node, ref resultingNode);
		}
		
		public virtual bool EnterCompileUnit(CompileUnit node, ref CompileUnit resultingNode)
		{
			return true;
		}
		
		public virtual void LeaveCompileUnit(CompileUnit node, ref CompileUnit resultingNode)
		{
		}
		
		public virtual void OnTypeReference(TypeReference node, ref TypeReference resultingNode)
		{	
		}
		
		public virtual void OnPackage(Package node, ref Package resultingNode)
		{	
		}
		
		public virtual void OnUsing(Using node, ref Using resultingNode)
		{	
			if (EnterUsing(node, ref resultingNode))
			{		
				ReferenceExpression currentAssemblyReferenceValue = node.AssemblyReference;
				if (null != currentAssemblyReferenceValue)
				{	
					Node resultingAssemblyReferenceValue;				
					currentAssemblyReferenceValue.Switch(this, out resultingAssemblyReferenceValue);
					node.AssemblyReference = (ReferenceExpression)resultingAssemblyReferenceValue;
				}
				ReferenceExpression currentAliasValue = node.Alias;
				if (null != currentAliasValue)
				{	
					Node resultingAliasValue;				
					currentAliasValue.Switch(this, out resultingAliasValue);
					node.Alias = (ReferenceExpression)resultingAliasValue;
				}
			}
			LeaveUsing(node, ref resultingNode);
		}
		
		public virtual bool EnterUsing(Using node, ref Using resultingNode)
		{
			return true;
		}
		
		public virtual void LeaveUsing(Using node, ref Using resultingNode)
		{
		}
		
		public virtual void OnModule(Module node, ref Module resultingNode)
		{	
			if (EnterModule(node, ref resultingNode))
			{		
				Package currentPackageValue = node.Package;
				if (null != currentPackageValue)
				{	
					Node resultingPackageValue;				
					currentPackageValue.Switch(this, out resultingPackageValue);
					node.Package = (Package)resultingPackageValue;
				}
				Switch(node.Using);
				Block currentGlobalsValue = node.Globals;
				if (null != currentGlobalsValue)
				{	
					Node resultingGlobalsValue;				
					currentGlobalsValue.Switch(this, out resultingGlobalsValue);
					node.Globals = (Block)resultingGlobalsValue;
				}
				Switch(node.Attributes);
				Switch(node.Members);
				Switch(node.BaseTypes);
			}
			LeaveModule(node, ref resultingNode);
		}
		
		public virtual bool EnterModule(Module node, ref Module resultingNode)
		{
			return true;
		}
		
		public virtual void LeaveModule(Module node, ref Module resultingNode)
		{
		}
		
		public virtual void OnClassDefinition(ClassDefinition node, ref ClassDefinition resultingNode)
		{	
			if (EnterClassDefinition(node, ref resultingNode))
			{		
				Switch(node.Attributes);
				Switch(node.Members);
				Switch(node.BaseTypes);
			}
			LeaveClassDefinition(node, ref resultingNode);
		}
		
		public virtual bool EnterClassDefinition(ClassDefinition node, ref ClassDefinition resultingNode)
		{
			return true;
		}
		
		public virtual void LeaveClassDefinition(ClassDefinition node, ref ClassDefinition resultingNode)
		{
		}
		
		public virtual void OnInterfaceDefinition(InterfaceDefinition node, ref InterfaceDefinition resultingNode)
		{	
			if (EnterInterfaceDefinition(node, ref resultingNode))
			{		
				Switch(node.Attributes);
				Switch(node.Members);
				Switch(node.BaseTypes);
			}
			LeaveInterfaceDefinition(node, ref resultingNode);
		}
		
		public virtual bool EnterInterfaceDefinition(InterfaceDefinition node, ref InterfaceDefinition resultingNode)
		{
			return true;
		}
		
		public virtual void LeaveInterfaceDefinition(InterfaceDefinition node, ref InterfaceDefinition resultingNode)
		{
		}
		
		public virtual void OnEnumDefinition(EnumDefinition node, ref EnumDefinition resultingNode)
		{	
			if (EnterEnumDefinition(node, ref resultingNode))
			{		
				Switch(node.Attributes);
				Switch(node.Members);
				Switch(node.BaseTypes);
			}
			LeaveEnumDefinition(node, ref resultingNode);
		}
		
		public virtual bool EnterEnumDefinition(EnumDefinition node, ref EnumDefinition resultingNode)
		{
			return true;
		}
		
		public virtual void LeaveEnumDefinition(EnumDefinition node, ref EnumDefinition resultingNode)
		{
		}
		
		public virtual void OnEnumMember(EnumMember node, ref EnumMember resultingNode)
		{	
			if (EnterEnumMember(node, ref resultingNode))
			{		
				IntegerLiteralExpression currentInitializerValue = node.Initializer;
				if (null != currentInitializerValue)
				{	
					Node resultingInitializerValue;				
					currentInitializerValue.Switch(this, out resultingInitializerValue);
					node.Initializer = (IntegerLiteralExpression)resultingInitializerValue;
				}
				Switch(node.Attributes);
			}
			LeaveEnumMember(node, ref resultingNode);
		}
		
		public virtual bool EnterEnumMember(EnumMember node, ref EnumMember resultingNode)
		{
			return true;
		}
		
		public virtual void LeaveEnumMember(EnumMember node, ref EnumMember resultingNode)
		{
		}
		
		public virtual void OnField(Field node, ref Field resultingNode)
		{	
			if (EnterField(node, ref resultingNode))
			{		
				TypeReference currentTypeValue = node.Type;
				if (null != currentTypeValue)
				{	
					Node resultingTypeValue;				
					currentTypeValue.Switch(this, out resultingTypeValue);
					node.Type = (TypeReference)resultingTypeValue;
				}
				Switch(node.Attributes);
			}
			LeaveField(node, ref resultingNode);
		}
		
		public virtual bool EnterField(Field node, ref Field resultingNode)
		{
			return true;
		}
		
		public virtual void LeaveField(Field node, ref Field resultingNode)
		{
		}
		
		public virtual void OnProperty(Property node, ref Property resultingNode)
		{	
			if (EnterProperty(node, ref resultingNode))
			{		
				Method currentGetterValue = node.Getter;
				if (null != currentGetterValue)
				{	
					Node resultingGetterValue;				
					currentGetterValue.Switch(this, out resultingGetterValue);
					node.Getter = (Method)resultingGetterValue;
				}
				Method currentSetterValue = node.Setter;
				if (null != currentSetterValue)
				{	
					Node resultingSetterValue;				
					currentSetterValue.Switch(this, out resultingSetterValue);
					node.Setter = (Method)resultingSetterValue;
				}
				TypeReference currentTypeValue = node.Type;
				if (null != currentTypeValue)
				{	
					Node resultingTypeValue;				
					currentTypeValue.Switch(this, out resultingTypeValue);
					node.Type = (TypeReference)resultingTypeValue;
				}
				Switch(node.Attributes);
			}
			LeaveProperty(node, ref resultingNode);
		}
		
		public virtual bool EnterProperty(Property node, ref Property resultingNode)
		{
			return true;
		}
		
		public virtual void LeaveProperty(Property node, ref Property resultingNode)
		{
		}
		
		public virtual void OnLocal(Local node, ref Local resultingNode)
		{	
		}
		
		public virtual void OnMethod(Method node, ref Method resultingNode)
		{	
			if (EnterMethod(node, ref resultingNode))
			{		
				Switch(node.Parameters);
				TypeReference currentReturnTypeValue = node.ReturnType;
				if (null != currentReturnTypeValue)
				{	
					Node resultingReturnTypeValue;				
					currentReturnTypeValue.Switch(this, out resultingReturnTypeValue);
					node.ReturnType = (TypeReference)resultingReturnTypeValue;
				}
				Switch(node.ReturnTypeAttributes);
				Block currentBodyValue = node.Body;
				if (null != currentBodyValue)
				{	
					Node resultingBodyValue;				
					currentBodyValue.Switch(this, out resultingBodyValue);
					node.Body = (Block)resultingBodyValue;
				}
				Switch(node.Locals);
				Switch(node.Attributes);
			}
			LeaveMethod(node, ref resultingNode);
		}
		
		public virtual bool EnterMethod(Method node, ref Method resultingNode)
		{
			return true;
		}
		
		public virtual void LeaveMethod(Method node, ref Method resultingNode)
		{
		}
		
		public virtual void OnConstructor(Constructor node, ref Constructor resultingNode)
		{	
			if (EnterConstructor(node, ref resultingNode))
			{		
				Switch(node.Attributes);
				Switch(node.Parameters);
				TypeReference currentReturnTypeValue = node.ReturnType;
				if (null != currentReturnTypeValue)
				{	
					Node resultingReturnTypeValue;				
					currentReturnTypeValue.Switch(this, out resultingReturnTypeValue);
					node.ReturnType = (TypeReference)resultingReturnTypeValue;
				}
				Switch(node.ReturnTypeAttributes);
				Block currentBodyValue = node.Body;
				if (null != currentBodyValue)
				{	
					Node resultingBodyValue;				
					currentBodyValue.Switch(this, out resultingBodyValue);
					node.Body = (Block)resultingBodyValue;
				}
				Switch(node.Locals);
			}
			LeaveConstructor(node, ref resultingNode);
		}
		
		public virtual bool EnterConstructor(Constructor node, ref Constructor resultingNode)
		{
			return true;
		}
		
		public virtual void LeaveConstructor(Constructor node, ref Constructor resultingNode)
		{
		}
		
		public virtual void OnParameterDeclaration(ParameterDeclaration node, ref ParameterDeclaration resultingNode)
		{	
			if (EnterParameterDeclaration(node, ref resultingNode))
			{		
				TypeReference currentTypeValue = node.Type;
				if (null != currentTypeValue)
				{	
					Node resultingTypeValue;				
					currentTypeValue.Switch(this, out resultingTypeValue);
					node.Type = (TypeReference)resultingTypeValue;
				}
				Switch(node.Attributes);
			}
			LeaveParameterDeclaration(node, ref resultingNode);
		}
		
		public virtual bool EnterParameterDeclaration(ParameterDeclaration node, ref ParameterDeclaration resultingNode)
		{
			return true;
		}
		
		public virtual void LeaveParameterDeclaration(ParameterDeclaration node, ref ParameterDeclaration resultingNode)
		{
		}
		
		public virtual void OnDeclaration(Declaration node, ref Declaration resultingNode)
		{	
			if (EnterDeclaration(node, ref resultingNode))
			{		
				TypeReference currentTypeValue = node.Type;
				if (null != currentTypeValue)
				{	
					Node resultingTypeValue;				
					currentTypeValue.Switch(this, out resultingTypeValue);
					node.Type = (TypeReference)resultingTypeValue;
				}
			}
			LeaveDeclaration(node, ref resultingNode);
		}
		
		public virtual bool EnterDeclaration(Declaration node, ref Declaration resultingNode)
		{
			return true;
		}
		
		public virtual void LeaveDeclaration(Declaration node, ref Declaration resultingNode)
		{
		}
		
		public virtual void OnBlock(Block node, ref Block resultingNode)
		{	
			if (EnterBlock(node, ref resultingNode))
			{		
				Switch(node.Statements);
			}
			LeaveBlock(node, ref resultingNode);
		}
		
		public virtual bool EnterBlock(Block node, ref Block resultingNode)
		{
			return true;
		}
		
		public virtual void LeaveBlock(Block node, ref Block resultingNode)
		{
		}
		
		public virtual void OnAttribute(Attribute node, ref Attribute resultingNode)
		{	
			if (EnterAttribute(node, ref resultingNode))
			{		
				Switch(node.Arguments);
				Switch(node.NamedArguments);
			}
			LeaveAttribute(node, ref resultingNode);
		}
		
		public virtual bool EnterAttribute(Attribute node, ref Attribute resultingNode)
		{
			return true;
		}
		
		public virtual void LeaveAttribute(Attribute node, ref Attribute resultingNode)
		{
		}
		
		public virtual void OnStatementModifier(StatementModifier node, ref StatementModifier resultingNode)
		{	
			if (EnterStatementModifier(node, ref resultingNode))
			{		
				Expression currentConditionValue = node.Condition;
				if (null != currentConditionValue)
				{	
					Node resultingConditionValue;				
					currentConditionValue.Switch(this, out resultingConditionValue);
					node.Condition = (Expression)resultingConditionValue;
				}
			}
			LeaveStatementModifier(node, ref resultingNode);
		}
		
		public virtual bool EnterStatementModifier(StatementModifier node, ref StatementModifier resultingNode)
		{
			return true;
		}
		
		public virtual void LeaveStatementModifier(StatementModifier node, ref StatementModifier resultingNode)
		{
		}
		
		public virtual void OnDeclarationStatement(DeclarationStatement node, ref Statement resultingNode)
		{	
			if (EnterDeclarationStatement(node, ref resultingNode))
			{		
				Declaration currentDeclarationValue = node.Declaration;
				if (null != currentDeclarationValue)
				{	
					Node resultingDeclarationValue;				
					currentDeclarationValue.Switch(this, out resultingDeclarationValue);
					node.Declaration = (Declaration)resultingDeclarationValue;
				}
				Expression currentInitializerValue = node.Initializer;
				if (null != currentInitializerValue)
				{	
					Node resultingInitializerValue;				
					currentInitializerValue.Switch(this, out resultingInitializerValue);
					node.Initializer = (Expression)resultingInitializerValue;
				}
				StatementModifier currentModifierValue = node.Modifier;
				if (null != currentModifierValue)
				{	
					Node resultingModifierValue;				
					currentModifierValue.Switch(this, out resultingModifierValue);
					node.Modifier = (StatementModifier)resultingModifierValue;
				}
			}
			LeaveDeclarationStatement(node, ref resultingNode);
		}
		
		public virtual bool EnterDeclarationStatement(DeclarationStatement node, ref Statement resultingNode)
		{
			return true;
		}
		
		public virtual void LeaveDeclarationStatement(DeclarationStatement node, ref Statement resultingNode)
		{
		}
		
		public virtual void OnAssertStatement(AssertStatement node, ref Statement resultingNode)
		{	
			if (EnterAssertStatement(node, ref resultingNode))
			{		
				Expression currentConditionValue = node.Condition;
				if (null != currentConditionValue)
				{	
					Node resultingConditionValue;				
					currentConditionValue.Switch(this, out resultingConditionValue);
					node.Condition = (Expression)resultingConditionValue;
				}
				Expression currentMessageValue = node.Message;
				if (null != currentMessageValue)
				{	
					Node resultingMessageValue;				
					currentMessageValue.Switch(this, out resultingMessageValue);
					node.Message = (Expression)resultingMessageValue;
				}
				StatementModifier currentModifierValue = node.Modifier;
				if (null != currentModifierValue)
				{	
					Node resultingModifierValue;				
					currentModifierValue.Switch(this, out resultingModifierValue);
					node.Modifier = (StatementModifier)resultingModifierValue;
				}
			}
			LeaveAssertStatement(node, ref resultingNode);
		}
		
		public virtual bool EnterAssertStatement(AssertStatement node, ref Statement resultingNode)
		{
			return true;
		}
		
		public virtual void LeaveAssertStatement(AssertStatement node, ref Statement resultingNode)
		{
		}
		
		public virtual void OnTryStatement(TryStatement node, ref Statement resultingNode)
		{	
			if (EnterTryStatement(node, ref resultingNode))
			{		
				Block currentProtectedBlockValue = node.ProtectedBlock;
				if (null != currentProtectedBlockValue)
				{	
					Node resultingProtectedBlockValue;				
					currentProtectedBlockValue.Switch(this, out resultingProtectedBlockValue);
					node.ProtectedBlock = (Block)resultingProtectedBlockValue;
				}
				Switch(node.ExceptionHandlers);
				Block currentSuccessBlockValue = node.SuccessBlock;
				if (null != currentSuccessBlockValue)
				{	
					Node resultingSuccessBlockValue;				
					currentSuccessBlockValue.Switch(this, out resultingSuccessBlockValue);
					node.SuccessBlock = (Block)resultingSuccessBlockValue;
				}
				Block currentEnsureBlockValue = node.EnsureBlock;
				if (null != currentEnsureBlockValue)
				{	
					Node resultingEnsureBlockValue;				
					currentEnsureBlockValue.Switch(this, out resultingEnsureBlockValue);
					node.EnsureBlock = (Block)resultingEnsureBlockValue;
				}
				StatementModifier currentModifierValue = node.Modifier;
				if (null != currentModifierValue)
				{	
					Node resultingModifierValue;				
					currentModifierValue.Switch(this, out resultingModifierValue);
					node.Modifier = (StatementModifier)resultingModifierValue;
				}
			}
			LeaveTryStatement(node, ref resultingNode);
		}
		
		public virtual bool EnterTryStatement(TryStatement node, ref Statement resultingNode)
		{
			return true;
		}
		
		public virtual void LeaveTryStatement(TryStatement node, ref Statement resultingNode)
		{
		}
		
		public virtual void OnExceptionHandler(ExceptionHandler node, ref ExceptionHandler resultingNode)
		{	
			if (EnterExceptionHandler(node, ref resultingNode))
			{		
				Declaration currentDeclarationValue = node.Declaration;
				if (null != currentDeclarationValue)
				{	
					Node resultingDeclarationValue;				
					currentDeclarationValue.Switch(this, out resultingDeclarationValue);
					node.Declaration = (Declaration)resultingDeclarationValue;
				}
				Switch(node.Statements);
			}
			LeaveExceptionHandler(node, ref resultingNode);
		}
		
		public virtual bool EnterExceptionHandler(ExceptionHandler node, ref ExceptionHandler resultingNode)
		{
			return true;
		}
		
		public virtual void LeaveExceptionHandler(ExceptionHandler node, ref ExceptionHandler resultingNode)
		{
		}
		
		public virtual void OnIfStatement(IfStatement node, ref Statement resultingNode)
		{	
			if (EnterIfStatement(node, ref resultingNode))
			{		
				Expression currentExpressionValue = node.Expression;
				if (null != currentExpressionValue)
				{	
					Node resultingExpressionValue;				
					currentExpressionValue.Switch(this, out resultingExpressionValue);
					node.Expression = (Expression)resultingExpressionValue;
				}
				Block currentTrueBlockValue = node.TrueBlock;
				if (null != currentTrueBlockValue)
				{	
					Node resultingTrueBlockValue;				
					currentTrueBlockValue.Switch(this, out resultingTrueBlockValue);
					node.TrueBlock = (Block)resultingTrueBlockValue;
				}
				Block currentFalseBlockValue = node.FalseBlock;
				if (null != currentFalseBlockValue)
				{	
					Node resultingFalseBlockValue;				
					currentFalseBlockValue.Switch(this, out resultingFalseBlockValue);
					node.FalseBlock = (Block)resultingFalseBlockValue;
				}
				StatementModifier currentModifierValue = node.Modifier;
				if (null != currentModifierValue)
				{	
					Node resultingModifierValue;				
					currentModifierValue.Switch(this, out resultingModifierValue);
					node.Modifier = (StatementModifier)resultingModifierValue;
				}
			}
			LeaveIfStatement(node, ref resultingNode);
		}
		
		public virtual bool EnterIfStatement(IfStatement node, ref Statement resultingNode)
		{
			return true;
		}
		
		public virtual void LeaveIfStatement(IfStatement node, ref Statement resultingNode)
		{
		}
		
		public virtual void OnForStatement(ForStatement node, ref Statement resultingNode)
		{	
			if (EnterForStatement(node, ref resultingNode))
			{		
				Switch(node.Declarations);
				Expression currentIteratorValue = node.Iterator;
				if (null != currentIteratorValue)
				{	
					Node resultingIteratorValue;				
					currentIteratorValue.Switch(this, out resultingIteratorValue);
					node.Iterator = (Expression)resultingIteratorValue;
				}
				Switch(node.Statements);
				StatementModifier currentModifierValue = node.Modifier;
				if (null != currentModifierValue)
				{	
					Node resultingModifierValue;				
					currentModifierValue.Switch(this, out resultingModifierValue);
					node.Modifier = (StatementModifier)resultingModifierValue;
				}
			}
			LeaveForStatement(node, ref resultingNode);
		}
		
		public virtual bool EnterForStatement(ForStatement node, ref Statement resultingNode)
		{
			return true;
		}
		
		public virtual void LeaveForStatement(ForStatement node, ref Statement resultingNode)
		{
		}
		
		public virtual void OnWhileStatement(WhileStatement node, ref Statement resultingNode)
		{	
			if (EnterWhileStatement(node, ref resultingNode))
			{		
				Expression currentConditionValue = node.Condition;
				if (null != currentConditionValue)
				{	
					Node resultingConditionValue;				
					currentConditionValue.Switch(this, out resultingConditionValue);
					node.Condition = (Expression)resultingConditionValue;
				}
				Switch(node.Statements);
				StatementModifier currentModifierValue = node.Modifier;
				if (null != currentModifierValue)
				{	
					Node resultingModifierValue;				
					currentModifierValue.Switch(this, out resultingModifierValue);
					node.Modifier = (StatementModifier)resultingModifierValue;
				}
			}
			LeaveWhileStatement(node, ref resultingNode);
		}
		
		public virtual bool EnterWhileStatement(WhileStatement node, ref Statement resultingNode)
		{
			return true;
		}
		
		public virtual void LeaveWhileStatement(WhileStatement node, ref Statement resultingNode)
		{
		}
		
		public virtual void OnGivenStatement(GivenStatement node, ref Statement resultingNode)
		{	
			if (EnterGivenStatement(node, ref resultingNode))
			{		
				Expression currentExpressionValue = node.Expression;
				if (null != currentExpressionValue)
				{	
					Node resultingExpressionValue;				
					currentExpressionValue.Switch(this, out resultingExpressionValue);
					node.Expression = (Expression)resultingExpressionValue;
				}
				Switch(node.WhenClauses);
				Block currentOtherwiseBlockValue = node.OtherwiseBlock;
				if (null != currentOtherwiseBlockValue)
				{	
					Node resultingOtherwiseBlockValue;				
					currentOtherwiseBlockValue.Switch(this, out resultingOtherwiseBlockValue);
					node.OtherwiseBlock = (Block)resultingOtherwiseBlockValue;
				}
				StatementModifier currentModifierValue = node.Modifier;
				if (null != currentModifierValue)
				{	
					Node resultingModifierValue;				
					currentModifierValue.Switch(this, out resultingModifierValue);
					node.Modifier = (StatementModifier)resultingModifierValue;
				}
			}
			LeaveGivenStatement(node, ref resultingNode);
		}
		
		public virtual bool EnterGivenStatement(GivenStatement node, ref Statement resultingNode)
		{
			return true;
		}
		
		public virtual void LeaveGivenStatement(GivenStatement node, ref Statement resultingNode)
		{
		}
		
		public virtual void OnWhenClause(WhenClause node, ref WhenClause resultingNode)
		{	
			if (EnterWhenClause(node, ref resultingNode))
			{		
				Expression currentConditionValue = node.Condition;
				if (null != currentConditionValue)
				{	
					Node resultingConditionValue;				
					currentConditionValue.Switch(this, out resultingConditionValue);
					node.Condition = (Expression)resultingConditionValue;
				}
				Switch(node.Statements);
			}
			LeaveWhenClause(node, ref resultingNode);
		}
		
		public virtual bool EnterWhenClause(WhenClause node, ref WhenClause resultingNode)
		{
			return true;
		}
		
		public virtual void LeaveWhenClause(WhenClause node, ref WhenClause resultingNode)
		{
		}
		
		public virtual void OnBreakStatement(BreakStatement node, ref Statement resultingNode)
		{	
			if (EnterBreakStatement(node, ref resultingNode))
			{		
				StatementModifier currentModifierValue = node.Modifier;
				if (null != currentModifierValue)
				{	
					Node resultingModifierValue;				
					currentModifierValue.Switch(this, out resultingModifierValue);
					node.Modifier = (StatementModifier)resultingModifierValue;
				}
			}
			LeaveBreakStatement(node, ref resultingNode);
		}
		
		public virtual bool EnterBreakStatement(BreakStatement node, ref Statement resultingNode)
		{
			return true;
		}
		
		public virtual void LeaveBreakStatement(BreakStatement node, ref Statement resultingNode)
		{
		}
		
		public virtual void OnContinueStatement(ContinueStatement node, ref Statement resultingNode)
		{	
			if (EnterContinueStatement(node, ref resultingNode))
			{		
				StatementModifier currentModifierValue = node.Modifier;
				if (null != currentModifierValue)
				{	
					Node resultingModifierValue;				
					currentModifierValue.Switch(this, out resultingModifierValue);
					node.Modifier = (StatementModifier)resultingModifierValue;
				}
			}
			LeaveContinueStatement(node, ref resultingNode);
		}
		
		public virtual bool EnterContinueStatement(ContinueStatement node, ref Statement resultingNode)
		{
			return true;
		}
		
		public virtual void LeaveContinueStatement(ContinueStatement node, ref Statement resultingNode)
		{
		}
		
		public virtual void OnRetryStatement(RetryStatement node, ref Statement resultingNode)
		{	
			if (EnterRetryStatement(node, ref resultingNode))
			{		
				StatementModifier currentModifierValue = node.Modifier;
				if (null != currentModifierValue)
				{	
					Node resultingModifierValue;				
					currentModifierValue.Switch(this, out resultingModifierValue);
					node.Modifier = (StatementModifier)resultingModifierValue;
				}
			}
			LeaveRetryStatement(node, ref resultingNode);
		}
		
		public virtual bool EnterRetryStatement(RetryStatement node, ref Statement resultingNode)
		{
			return true;
		}
		
		public virtual void LeaveRetryStatement(RetryStatement node, ref Statement resultingNode)
		{
		}
		
		public virtual void OnReturnStatement(ReturnStatement node, ref Statement resultingNode)
		{	
			if (EnterReturnStatement(node, ref resultingNode))
			{		
				Expression currentExpressionValue = node.Expression;
				if (null != currentExpressionValue)
				{	
					Node resultingExpressionValue;				
					currentExpressionValue.Switch(this, out resultingExpressionValue);
					node.Expression = (Expression)resultingExpressionValue;
				}
				StatementModifier currentModifierValue = node.Modifier;
				if (null != currentModifierValue)
				{	
					Node resultingModifierValue;				
					currentModifierValue.Switch(this, out resultingModifierValue);
					node.Modifier = (StatementModifier)resultingModifierValue;
				}
			}
			LeaveReturnStatement(node, ref resultingNode);
		}
		
		public virtual bool EnterReturnStatement(ReturnStatement node, ref Statement resultingNode)
		{
			return true;
		}
		
		public virtual void LeaveReturnStatement(ReturnStatement node, ref Statement resultingNode)
		{
		}
		
		public virtual void OnYieldStatement(YieldStatement node, ref Statement resultingNode)
		{	
			if (EnterYieldStatement(node, ref resultingNode))
			{		
				Expression currentExpressionValue = node.Expression;
				if (null != currentExpressionValue)
				{	
					Node resultingExpressionValue;				
					currentExpressionValue.Switch(this, out resultingExpressionValue);
					node.Expression = (Expression)resultingExpressionValue;
				}
				StatementModifier currentModifierValue = node.Modifier;
				if (null != currentModifierValue)
				{	
					Node resultingModifierValue;				
					currentModifierValue.Switch(this, out resultingModifierValue);
					node.Modifier = (StatementModifier)resultingModifierValue;
				}
			}
			LeaveYieldStatement(node, ref resultingNode);
		}
		
		public virtual bool EnterYieldStatement(YieldStatement node, ref Statement resultingNode)
		{
			return true;
		}
		
		public virtual void LeaveYieldStatement(YieldStatement node, ref Statement resultingNode)
		{
		}
		
		public virtual void OnRaiseStatement(RaiseStatement node, ref Statement resultingNode)
		{	
			if (EnterRaiseStatement(node, ref resultingNode))
			{		
				Expression currentExceptionValue = node.Exception;
				if (null != currentExceptionValue)
				{	
					Node resultingExceptionValue;				
					currentExceptionValue.Switch(this, out resultingExceptionValue);
					node.Exception = (Expression)resultingExceptionValue;
				}
				StatementModifier currentModifierValue = node.Modifier;
				if (null != currentModifierValue)
				{	
					Node resultingModifierValue;				
					currentModifierValue.Switch(this, out resultingModifierValue);
					node.Modifier = (StatementModifier)resultingModifierValue;
				}
			}
			LeaveRaiseStatement(node, ref resultingNode);
		}
		
		public virtual bool EnterRaiseStatement(RaiseStatement node, ref Statement resultingNode)
		{
			return true;
		}
		
		public virtual void LeaveRaiseStatement(RaiseStatement node, ref Statement resultingNode)
		{
		}
		
		public virtual void OnUnpackStatement(UnpackStatement node, ref Statement resultingNode)
		{	
			if (EnterUnpackStatement(node, ref resultingNode))
			{		
				Switch(node.Declarations);
				Expression currentExpressionValue = node.Expression;
				if (null != currentExpressionValue)
				{	
					Node resultingExpressionValue;				
					currentExpressionValue.Switch(this, out resultingExpressionValue);
					node.Expression = (Expression)resultingExpressionValue;
				}
				StatementModifier currentModifierValue = node.Modifier;
				if (null != currentModifierValue)
				{	
					Node resultingModifierValue;				
					currentModifierValue.Switch(this, out resultingModifierValue);
					node.Modifier = (StatementModifier)resultingModifierValue;
				}
			}
			LeaveUnpackStatement(node, ref resultingNode);
		}
		
		public virtual bool EnterUnpackStatement(UnpackStatement node, ref Statement resultingNode)
		{
			return true;
		}
		
		public virtual void LeaveUnpackStatement(UnpackStatement node, ref Statement resultingNode)
		{
		}
		
		public virtual void OnExpressionStatement(ExpressionStatement node, ref Statement resultingNode)
		{	
			if (EnterExpressionStatement(node, ref resultingNode))
			{		
				Expression currentExpressionValue = node.Expression;
				if (null != currentExpressionValue)
				{	
					Node resultingExpressionValue;				
					currentExpressionValue.Switch(this, out resultingExpressionValue);
					node.Expression = (Expression)resultingExpressionValue;
				}
				StatementModifier currentModifierValue = node.Modifier;
				if (null != currentModifierValue)
				{	
					Node resultingModifierValue;				
					currentModifierValue.Switch(this, out resultingModifierValue);
					node.Modifier = (StatementModifier)resultingModifierValue;
				}
			}
			LeaveExpressionStatement(node, ref resultingNode);
		}
		
		public virtual bool EnterExpressionStatement(ExpressionStatement node, ref Statement resultingNode)
		{
			return true;
		}
		
		public virtual void LeaveExpressionStatement(ExpressionStatement node, ref Statement resultingNode)
		{
		}
		
		public virtual void OnOmittedExpression(OmittedExpression node, ref Expression resultingNode)
		{	
		}
		
		public virtual void OnExpressionPair(ExpressionPair node, ref ExpressionPair resultingNode)
		{	
			if (EnterExpressionPair(node, ref resultingNode))
			{		
				Expression currentFirstValue = node.First;
				if (null != currentFirstValue)
				{	
					Node resultingFirstValue;				
					currentFirstValue.Switch(this, out resultingFirstValue);
					node.First = (Expression)resultingFirstValue;
				}
				Expression currentSecondValue = node.Second;
				if (null != currentSecondValue)
				{	
					Node resultingSecondValue;				
					currentSecondValue.Switch(this, out resultingSecondValue);
					node.Second = (Expression)resultingSecondValue;
				}
			}
			LeaveExpressionPair(node, ref resultingNode);
		}
		
		public virtual bool EnterExpressionPair(ExpressionPair node, ref ExpressionPair resultingNode)
		{
			return true;
		}
		
		public virtual void LeaveExpressionPair(ExpressionPair node, ref ExpressionPair resultingNode)
		{
		}
		
		public virtual void OnMethodInvocationExpression(MethodInvocationExpression node, ref Expression resultingNode)
		{	
			if (EnterMethodInvocationExpression(node, ref resultingNode))
			{		
				Expression currentTargetValue = node.Target;
				if (null != currentTargetValue)
				{	
					Node resultingTargetValue;				
					currentTargetValue.Switch(this, out resultingTargetValue);
					node.Target = (Expression)resultingTargetValue;
				}
				Switch(node.Arguments);
				Switch(node.NamedArguments);
			}
			LeaveMethodInvocationExpression(node, ref resultingNode);
		}
		
		public virtual bool EnterMethodInvocationExpression(MethodInvocationExpression node, ref Expression resultingNode)
		{
			return true;
		}
		
		public virtual void LeaveMethodInvocationExpression(MethodInvocationExpression node, ref Expression resultingNode)
		{
		}
		
		public virtual void OnUnaryExpression(UnaryExpression node, ref Expression resultingNode)
		{	
			if (EnterUnaryExpression(node, ref resultingNode))
			{		
				Expression currentOperandValue = node.Operand;
				if (null != currentOperandValue)
				{	
					Node resultingOperandValue;				
					currentOperandValue.Switch(this, out resultingOperandValue);
					node.Operand = (Expression)resultingOperandValue;
				}
			}
			LeaveUnaryExpression(node, ref resultingNode);
		}
		
		public virtual bool EnterUnaryExpression(UnaryExpression node, ref Expression resultingNode)
		{
			return true;
		}
		
		public virtual void LeaveUnaryExpression(UnaryExpression node, ref Expression resultingNode)
		{
		}
		
		public virtual void OnBinaryExpression(BinaryExpression node, ref Expression resultingNode)
		{	
			if (EnterBinaryExpression(node, ref resultingNode))
			{		
				Expression currentLeftValue = node.Left;
				if (null != currentLeftValue)
				{	
					Node resultingLeftValue;				
					currentLeftValue.Switch(this, out resultingLeftValue);
					node.Left = (Expression)resultingLeftValue;
				}
				Expression currentRightValue = node.Right;
				if (null != currentRightValue)
				{	
					Node resultingRightValue;				
					currentRightValue.Switch(this, out resultingRightValue);
					node.Right = (Expression)resultingRightValue;
				}
			}
			LeaveBinaryExpression(node, ref resultingNode);
		}
		
		public virtual bool EnterBinaryExpression(BinaryExpression node, ref Expression resultingNode)
		{
			return true;
		}
		
		public virtual void LeaveBinaryExpression(BinaryExpression node, ref Expression resultingNode)
		{
		}
		
		public virtual void OnTernaryExpression(TernaryExpression node, ref Expression resultingNode)
		{	
			if (EnterTernaryExpression(node, ref resultingNode))
			{		
				Expression currentConditionValue = node.Condition;
				if (null != currentConditionValue)
				{	
					Node resultingConditionValue;				
					currentConditionValue.Switch(this, out resultingConditionValue);
					node.Condition = (Expression)resultingConditionValue;
				}
				Expression currentTrueExpressionValue = node.TrueExpression;
				if (null != currentTrueExpressionValue)
				{	
					Node resultingTrueExpressionValue;				
					currentTrueExpressionValue.Switch(this, out resultingTrueExpressionValue);
					node.TrueExpression = (Expression)resultingTrueExpressionValue;
				}
				Expression currentFalseExpressionValue = node.FalseExpression;
				if (null != currentFalseExpressionValue)
				{	
					Node resultingFalseExpressionValue;				
					currentFalseExpressionValue.Switch(this, out resultingFalseExpressionValue);
					node.FalseExpression = (Expression)resultingFalseExpressionValue;
				}
			}
			LeaveTernaryExpression(node, ref resultingNode);
		}
		
		public virtual bool EnterTernaryExpression(TernaryExpression node, ref Expression resultingNode)
		{
			return true;
		}
		
		public virtual void LeaveTernaryExpression(TernaryExpression node, ref Expression resultingNode)
		{
		}
		
		public virtual void OnReferenceExpression(ReferenceExpression node, ref Expression resultingNode)
		{	
		}
		
		public virtual void OnMemberReferenceExpression(MemberReferenceExpression node, ref Expression resultingNode)
		{	
			if (EnterMemberReferenceExpression(node, ref resultingNode))
			{		
				Expression currentTargetValue = node.Target;
				if (null != currentTargetValue)
				{	
					Node resultingTargetValue;				
					currentTargetValue.Switch(this, out resultingTargetValue);
					node.Target = (Expression)resultingTargetValue;
				}
			}
			LeaveMemberReferenceExpression(node, ref resultingNode);
		}
		
		public virtual bool EnterMemberReferenceExpression(MemberReferenceExpression node, ref Expression resultingNode)
		{
			return true;
		}
		
		public virtual void LeaveMemberReferenceExpression(MemberReferenceExpression node, ref Expression resultingNode)
		{
		}
		
		public virtual void OnLiteralExpression(LiteralExpression node, ref Expression resultingNode)
		{	
		}
		
		public virtual void OnStringLiteralExpression(StringLiteralExpression node, ref Expression resultingNode)
		{	
		}
		
		public virtual void OnTimeSpanLiteralExpression(TimeSpanLiteralExpression node, ref Expression resultingNode)
		{	
		}
		
		public virtual void OnIntegerLiteralExpression(IntegerLiteralExpression node, ref Expression resultingNode)
		{	
		}
		
		public virtual void OnNullLiteralExpression(NullLiteralExpression node, ref Expression resultingNode)
		{	
		}
		
		public virtual void OnSelfLiteralExpression(SelfLiteralExpression node, ref Expression resultingNode)
		{	
		}
		
		public virtual void OnSuperLiteralExpression(SuperLiteralExpression node, ref Expression resultingNode)
		{	
		}
		
		public virtual void OnBoolLiteralExpression(BoolLiteralExpression node, ref Expression resultingNode)
		{	
		}
		
		public virtual void OnRELiteralExpression(RELiteralExpression node, ref Expression resultingNode)
		{	
		}
		
		public virtual void OnStringFormattingExpression(StringFormattingExpression node, ref Expression resultingNode)
		{	
			if (EnterStringFormattingExpression(node, ref resultingNode))
			{		
				Switch(node.Arguments);
			}
			LeaveStringFormattingExpression(node, ref resultingNode);
		}
		
		public virtual bool EnterStringFormattingExpression(StringFormattingExpression node, ref Expression resultingNode)
		{
			return true;
		}
		
		public virtual void LeaveStringFormattingExpression(StringFormattingExpression node, ref Expression resultingNode)
		{
		}
		
		public virtual void OnHashLiteralExpression(HashLiteralExpression node, ref Expression resultingNode)
		{	
			if (EnterHashLiteralExpression(node, ref resultingNode))
			{		
				Switch(node.Items);
			}
			LeaveHashLiteralExpression(node, ref resultingNode);
		}
		
		public virtual bool EnterHashLiteralExpression(HashLiteralExpression node, ref Expression resultingNode)
		{
			return true;
		}
		
		public virtual void LeaveHashLiteralExpression(HashLiteralExpression node, ref Expression resultingNode)
		{
		}
		
		public virtual void OnListLiteralExpression(ListLiteralExpression node, ref Expression resultingNode)
		{	
			if (EnterListLiteralExpression(node, ref resultingNode))
			{		
				Switch(node.Items);
			}
			LeaveListLiteralExpression(node, ref resultingNode);
		}
		
		public virtual bool EnterListLiteralExpression(ListLiteralExpression node, ref Expression resultingNode)
		{
			return true;
		}
		
		public virtual void LeaveListLiteralExpression(ListLiteralExpression node, ref Expression resultingNode)
		{
		}
		
		public virtual void OnTupleLiteralExpression(TupleLiteralExpression node, ref Expression resultingNode)
		{	
			if (EnterTupleLiteralExpression(node, ref resultingNode))
			{		
				Switch(node.Items);
			}
			LeaveTupleLiteralExpression(node, ref resultingNode);
		}
		
		public virtual bool EnterTupleLiteralExpression(TupleLiteralExpression node, ref Expression resultingNode)
		{
			return true;
		}
		
		public virtual void LeaveTupleLiteralExpression(TupleLiteralExpression node, ref Expression resultingNode)
		{
		}
		
		public virtual void OnListDisplayExpression(ListDisplayExpression node, ref Expression resultingNode)
		{	
			if (EnterListDisplayExpression(node, ref resultingNode))
			{		
				Expression currentExpressionValue = node.Expression;
				if (null != currentExpressionValue)
				{	
					Node resultingExpressionValue;				
					currentExpressionValue.Switch(this, out resultingExpressionValue);
					node.Expression = (Expression)resultingExpressionValue;
				}
				Switch(node.Declarations);
				Expression currentIteratorValue = node.Iterator;
				if (null != currentIteratorValue)
				{	
					Node resultingIteratorValue;				
					currentIteratorValue.Switch(this, out resultingIteratorValue);
					node.Iterator = (Expression)resultingIteratorValue;
				}
				StatementModifier currentFilterValue = node.Filter;
				if (null != currentFilterValue)
				{	
					Node resultingFilterValue;				
					currentFilterValue.Switch(this, out resultingFilterValue);
					node.Filter = (StatementModifier)resultingFilterValue;
				}
			}
			LeaveListDisplayExpression(node, ref resultingNode);
		}
		
		public virtual bool EnterListDisplayExpression(ListDisplayExpression node, ref Expression resultingNode)
		{
			return true;
		}
		
		public virtual void LeaveListDisplayExpression(ListDisplayExpression node, ref Expression resultingNode)
		{
		}
		
		public virtual void OnSlicingExpression(SlicingExpression node, ref Expression resultingNode)
		{	
			if (EnterSlicingExpression(node, ref resultingNode))
			{		
				Expression currentTargetValue = node.Target;
				if (null != currentTargetValue)
				{	
					Node resultingTargetValue;				
					currentTargetValue.Switch(this, out resultingTargetValue);
					node.Target = (Expression)resultingTargetValue;
				}
				Expression currentBeginValue = node.Begin;
				if (null != currentBeginValue)
				{	
					Node resultingBeginValue;				
					currentBeginValue.Switch(this, out resultingBeginValue);
					node.Begin = (Expression)resultingBeginValue;
				}
				Expression currentEndValue = node.End;
				if (null != currentEndValue)
				{	
					Node resultingEndValue;				
					currentEndValue.Switch(this, out resultingEndValue);
					node.End = (Expression)resultingEndValue;
				}
				Expression currentStepValue = node.Step;
				if (null != currentStepValue)
				{	
					Node resultingStepValue;				
					currentStepValue.Switch(this, out resultingStepValue);
					node.Step = (Expression)resultingStepValue;
				}
			}
			LeaveSlicingExpression(node, ref resultingNode);
		}
		
		public virtual bool EnterSlicingExpression(SlicingExpression node, ref Expression resultingNode)
		{
			return true;
		}
		
		public virtual void LeaveSlicingExpression(SlicingExpression node, ref Expression resultingNode)
		{
		}
		
		public virtual void OnAsExpression(AsExpression node, ref Expression resultingNode)
		{	
			if (EnterAsExpression(node, ref resultingNode))
			{		
				Expression currentTargetValue = node.Target;
				if (null != currentTargetValue)
				{	
					Node resultingTargetValue;				
					currentTargetValue.Switch(this, out resultingTargetValue);
					node.Target = (Expression)resultingTargetValue;
				}
				TypeReference currentTypeValue = node.Type;
				if (null != currentTypeValue)
				{	
					Node resultingTypeValue;				
					currentTypeValue.Switch(this, out resultingTypeValue);
					node.Type = (TypeReference)resultingTypeValue;
				}
			}
			LeaveAsExpression(node, ref resultingNode);
		}
		
		public virtual bool EnterAsExpression(AsExpression node, ref Expression resultingNode)
		{
			return true;
		}
		
		public virtual void LeaveAsExpression(AsExpression node, ref Expression resultingNode)
		{
		}
		
	}
}
