// import React, { useState } from "react";

// export const TextInputDisplay: React.FC = () => {
//   const [inputValue, setInputValue] = useState<string>("");

//   const handleChange = (event: React.ChangeEvent<HTMLInputElement>) => {
//     setInputValue(event.target.value);
//   };

//   return (
//     <div className="flex flex-col items-center">
//       <input
//         type="text"
//         value={inputValue}
//         onChange={handleChange}
//         className="border border-gray-300 rounded-lg p-2 mb-4"
//       />
//     </div>
//   );
// };

import React from "react";

interface TextInputProps {
  label: string;
  type?: string;
  name?: string;
  value?: string;
  onChange?: (e: React.ChangeEvent<HTMLInputElement>) => void;
}

export const TextInput: React.FC<TextInputProps> = ({
  label,
  type = "password",
  name,
  value,
  onChange,
}) => {
  return (
    <div className="mb-2">
      <label className="block text-sm font-medium text-sky-500">{label}</label>
      <input
        type={type}
        className="mt-1 block w-full p-1 border border-gray-300 rounded-lg"
        value={value}
        name={name}
        onChange={onChange}
      />
    </div>
  );
};
