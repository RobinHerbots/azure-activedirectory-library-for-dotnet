﻿//----------------------------------------------------------------------
// Copyright (c) Microsoft Open Technologies, Inc.
// All Rights Reserved
// Apache License 2.0
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
// http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//----------------------------------------------------------------------

namespace Microsoft.Experimental.IdentityModel.Clients.ActiveDirectory
{
    /// <summary>
    /// The exception type thrown when user returned by service does not match user in the request.
    /// </summary>
    public class AdalUserMismatchException : AdalException
    {
        /// <summary>
        ///  Initializes a new instance of the exception class.
        /// </summary>
        public AdalUserMismatchException(string requestedUser, string returnedUser)
            : base(AdalError.UserMismatch, 
                   string.Format(AdalErrorMessage.UserMismatch, returnedUser, requestedUser))
        {
            this.RequestedUser = requestedUser;
            this.ReturnedUser = returnedUser;
        }

        /// <summary>
        /// Gets the user requested from service.
        /// </summary>
        public string RequestedUser { get; private set; }

        /// <summary>
        /// Gets the user returned by service.
        /// </summary>
        public string ReturnedUser { get; private set; }

        /// <summary>
        /// Creates and returns a string representation of the current exception.
        /// </summary>
        /// <returns>A string representation of the current exception.</returns>
        public override string ToString()
        {
            return base.ToString() + string.Format("\n\tRequestedUser: {0}\n\tReturnedUser: {1}", this.RequestedUser, this.ReturnedUser);
        }
    }
}
