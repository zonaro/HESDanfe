/*
  Copyright 2010-2012 Stefano Chizzolini. http://www.pdfclown.org

  Contributors:
    * Stefano Chizzolini (original code developer, http://www.stefanochizzolini.it)

  This file should be part of the source code distribution of "PDF Clown library" (the
  Program): see the accompanying README files for more info.

  This Program is free software; you can redistribute it and/or modify it under the terms
  of the GNU Lesser General Public License as published by the Free Software Foundation;
  either version 3 of the License, or (at your option) any later version.

  This Program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY,
  either expressed or implied; without even the implied warranty of MERCHANTABILITY or
  FITNESS FOR A PARTICULAR PURPOSE. See the License for more details.

  You should have received a copy of the GNU Lesser General Public License along with this
  Program (see README files); if not, go to the GNU website (http://www.gnu.org/licenses/).

  Redistribution and use, with or without modification, are permitted provided that such
  redistributions retain the above copyright notice, license and disclaimer, along with
  this list of conditions.
*/

using System;
using System.Collections.Generic;
using HES.Objects;

namespace HES.Documents.Contents.ColorSpaces
{
    /**
      <summary>DeviceN color value [PDF:1.6:4.5.5].</summary>
    */

    [PDF(VersionEnum.PDF13)]
    public sealed class DeviceNColor
        : LeveledColor
    {
        /**
          <summary>Gets the color corresponding to the specified components.</summary>
          <param name="components">Color components to convert.</param>
        */

        #region Private Methods

        private static IList<PdfDirectObject> GetComponentValues(
            params double[] components
                                                                )
        {// TODO:normalize parameters!
            IList<PdfDirectObject> componentValues = new List<PdfDirectObject>();
            foreach (double component in components)
            { componentValues.Add(PdfReal.Get((component))); }
            return componentValues;
        }

        #endregion Private Methods

        #region Internal Constructors

        internal DeviceNColor(
        IList<PdfDirectObject> components
                             ) : base(
        null, //TODO:colorspace?
        new PdfArray(components)
                                     )
        { }

        #endregion Internal Constructors

        #region Public Constructors

        public DeviceNColor(
        params double[] components
                           ) : this(GetComponentValues(components))
        { }

        #endregion Public Constructors

        #region Public Methods

        public static DeviceNColor Get(
                          PdfArray components
                                      ) => (components != null
                ? new DeviceNColor(components)
                : null
                   );

        public override object Clone(
            Document context
                                    ) => throw new NotImplementedException();

        #endregion Public Methods
    }
}