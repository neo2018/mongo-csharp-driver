﻿/* Copyright 2010-2013 10gen Inc.
*
* Licensed under the Apache License, Version 2.0 (the "License");
* you may not use this file except in compliance with the License.
* You may obtain a copy of the License at
*
* http://www.apache.org/licenses/LICENSE-2.0
*
* Unless required by applicable law or agreed to in writing, software
* distributed under the License is distributed on an "AS IS" BASIS,
* WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
* See the License for the specific language governing permissions and
* limitations under the License.
*/

using System;
using MongoDB.Driver.Internal;

namespace MongoDB.Driver.Communication.FeatureDetection
{
    internal class WireVersionDependency : IFeatureDependency
    {
        // private fields
        private readonly Range<int> _range;

        // constructors
        public WireVersionDependency(int min, int max)
        {
            _range = new Range<int>(min, max);
        }

        // public methods
        public bool IsMet(FeatureContext context)
        {
            return _range.Intersects(context.IsMasterResult.WireVersion);
        }
    }
}