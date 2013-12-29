namespace Boo.NAnt

import System
import System.Collections
import System.Collections.Generic
import System.Text

class BooIncludeCollection(CollectionBase):
"""Collection of BooScriptInclude Elements"""
	
	public def constructor():
		super()
	
	public def constructor(collection as BooIncludeCollection):
		super()
		self.AddRange(collection)
	
	public def constructor(enumerable as IEnumerable[of BooScriptInclude]):
		super()
		self.AddRange(enumerable)
	
	public self[index as int] as BooScriptInclude:
		get:
			return super.List[index] as BooScriptInclude
		set:
			super.List[index] = value
	
	public def AddRange(items as (BooScriptInclude)):
		
		//assert items is not null
		for i in items:
			super.List.Add(i)
	
	public def AddRange(other_script_collection as IEnumerable[of BooScriptInclude]):
	""" Adds all script includes from other_script_collection into the current script include collection """
		//assert other_script_collection is not null
		for s in other_script_collection:
			super.List.Add(s)
	
	public def Contains(include_script as BooScriptInclude) as bool:
	""" Determines if the given include script is included in the Collection """
		for s as BooScriptInclude in super.List:
			if s.ScriptPath is not null and s.ScriptPath.Equals(include_script.ScriptPath, StringComparison.OrdinalIgnoreCase):
				return true;
		
		return false;
	
	public def IndexOf(item as BooScriptInclude) as int:
		return super.List.IndexOf(item)
		
	public def Insert(index as int, item as BooScriptInclude):
		super.List.Insert(index, item)
		
	public def CopyTo(array as (BooScriptInclude), index as int):
		//assert array is not null
		super.List.CopyTo(array, index)
		
	public def Remove(item as BooScriptInclude):
		super.List.Remove(item)
		
	public def Add(item as BooScriptInclude):
		super.List.Add(item)
	
	public override def ToString() as string:
		sb = StringBuilder()
		self.ToString(sb)
		return sb.ToString()
	
	public def ToString(string_builder as StringBuilder) as string:
		for s as BooScriptInclude in super.List:
			string_builder.AppendLine(s.ToString())
	