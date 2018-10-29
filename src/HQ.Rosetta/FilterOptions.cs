﻿// Copyright (c) HQ.IO Corporation. All rights reserved.
// Licensed under the Reciprocal Public License, Version 1.5. See LICENSE.md in the project root for license terms.

using System;
using System.Collections.Generic;
using System.Linq;

namespace HQ.Rosetta
{
	public class FilterOptions : IQueryValidator
	{
		public List<Filter> Fields { get; set; } = new List<Filter>();

		public bool Validate(Type type, QueryOptions options, out IEnumerable<Error> errors)
		{
			var list = FieldValidations.MustExistOnType(type, Fields.Select(x => x.Field));
			errors = list;
			return list.Count == 0;
		}
	}
}