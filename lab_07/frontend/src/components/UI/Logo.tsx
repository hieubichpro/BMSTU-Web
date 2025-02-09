import ballLogo from "../../assets/ball.png";
// export const Logo: React.FC = () => {
//   return (
//     <div className="logo-container">
//       <span className="logo-text">Football =</span>
//       <img src={ballLogo} alt="" className="logo-image" />
//     </div>
//   );
// };

// export const SomeText: React.FC = () => {
//   return <div className="logo-text">some text hehe</div>;
// };

export const Logo: React.FC = () => {
  return (
    <div className="flex">
      <span className="mr-4 text-2xl font-bold text-white">
        Football Tournament
      </span>
      <img src={ballLogo} className="h-10 w-10 object-contain"></img>
    </div>
  );
};
