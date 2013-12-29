namespace Boo.NAnt

import System
import NAnt.Core
import NAnt.Core.Types
import NAnt.Core.Attributes

class BooScriptInclude(Element):
"""Description of BooScriptInclude"""
	
	_script_path as string

	_if_defined = true
	
	_unless_defined = false
	
	public def constructor():
		super()

	public def constructor(script_path as string):
		super()
		_script_path = script_path
		
	[TaskAttributeAttribute("path")]
	ScriptPath as string:
		get:
			return _script_path
		set:
			_script_path = value
	
	[BooleanValidator]
	[TaskAttribute("if")]
	IfDefined as bool:
		get:
			return _if_defined
		set:
			_if_defined = value			
	
	
	[BooleanValidator]
	[TaskAttribute("unless")]
	UnlessDefined as bool:
		get:
			return _unless_defined
		set:
			_unless_defined = value
	
	public override def ToString() as string:
		return (_script_path if _script_path is not null else string.Empty)