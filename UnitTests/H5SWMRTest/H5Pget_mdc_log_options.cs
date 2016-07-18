﻿/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
 * Copyright by The HDF Group.                                               *
 * Copyright by the Board of Trustees of the University of Illinois.         *
 * All rights reserved.                                                      *
 *                                                                           *
 * This file is part of HDF5.  The full HDF5 copyright notice, including     *
 * terms governing use, modification, and redistribution, is contained in    *
 * the files COPYING and Copyright.html.  COPYING can be found at the root   *
 * of the source code distribution tree; Copyright.html can be found at the  *
 * root level of an installed copy of the electronic HDF5 document set and   *
 * is linked from the top-level documents page.  It can also be found at     *
 * http://hdfgroup.org/HDF5/doc/Copyright.html.  If you do not have          *
 * access to either file, you may request a copy from help@hdfgroup.org.     *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */

using System;
using System.Text;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HDF.PInvoke;

using hbool_t = System.UInt32;
using herr_t = System.Int32;


#if HDF5_VER1_10

using hid_t = System.Int64;

namespace UnitTests
{
    public partial class H5SWMRTest
    {
        [TestMethod]
        public void H5Fget_mdc_log_optionsTestSWMR1()
        {
            hid_t fapl = H5P.create(H5P.FILE_ACCESS);
            Assert.IsTrue(fapl >= 0);

            hbool_t is_enabled = 1;
            string location = "mdc.log";
            hbool_t start_on_access = 0;

            Assert.IsTrue(
                H5P.set_mdc_log_options(fapl, is_enabled, location,
                start_on_access) >= 0);
            
            StringBuilder sb = new StringBuilder(8);
            IntPtr size = new IntPtr();
            Assert.IsTrue(
                H5P.get_mdc_log_options(fapl, ref is_enabled, sb, ref size,
                ref start_on_access) >= 0);

            Assert.IsTrue(H5P.close(fapl) >= 0);
        }
    }
}

#endif