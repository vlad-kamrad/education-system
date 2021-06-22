import React, { useState } from 'react';
import EDUContext from './EDU.Context';

export default function ({ initialState, children }) {
  const [get, set] = useState(initialState);
  return (
    <EDUContext.Provider value={[get, set]}>{children}</EDUContext.Provider>
  );
}
