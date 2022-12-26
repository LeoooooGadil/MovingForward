using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public static class TextTransformer
{
	public static string SplitCamelCase(string _text)
	{
		return Regex.Replace(
			Regex.Replace(
				_text,
				@"(\P{Ll})(\P{Ll}\p{Ll})",
				"$1 $2"
			),
			@"(\p{Ll})(\P{Ll})",
			"$1 $2"
		);
	}
}
