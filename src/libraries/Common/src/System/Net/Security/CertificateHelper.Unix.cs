// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Security.Cryptography.X509Certificates;

namespace System.Net.Security
{
    internal static partial class CertificateHelper
    {
        internal static X509Certificate2? GetEligibleClientCertificate()
        {
            // Get initial list of client certificates from the MY store.
            X509Certificate2Collection candidateCerts;
            using (var myStore = new X509Store(StoreName.My, StoreLocation.CurrentUser))
            {
                myStore.Open(OpenFlags.ReadOnly);
                candidateCerts = myStore.Certificates;
            }

            return GetEligibleClientCertificate(candidateCerts);
        }
    }
}
