import React from "react";
import { NavBarAdmin } from "../UI/NavBarAdmin";
import { TextInput } from "../UI/InputText";
import { Button } from "../UI/Button";
import { UserTable } from "../UI/UserTable";
import { useState } from "react";
import { User, RawChangePassword } from "../../types/Users";
import { useEffect } from "react";
import { UserService } from "../../services/UserService";
import { getUser } from "../../utils/UserUtils";
export const AdminUserPage = () => {
  const [users, setUsers] = useState<User[]>([]);
  const [newUser, setNewUser] = useState({
    id: 0,
    login: "",
    password: "",
    role: "",
    name: "",
  });
  const [error, setError] = useState<string>("");
  const [info, setInfo] = useState<string>("");
  const handleUserSelect = (user: User) => {
    setNewUser(user);
  };
  const handleInputChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    const { name, value } = e.target;
    setNewUser({ ...newUser, [name]: value });
  };

  const fetchUsers = async () => {
    try {
      const response = await UserService.getAll(); 
      setUsers(response.data); 
    } catch (error) {
      console.error("Error fetching users:", error);
    }
  };

  useEffect(() => {
    fetchUsers();
  }, []);

  const handleDelete = async () => {
    try {
      await UserService.delete(newUser.id.toString());
      fetchUsers();
      setNewUser({ id: 0, login: "", password: "", role: "", name: "" }); 
    } catch (error) {
      setError("Error deleting");
    }
  };

  const handleAddUser = async () => {
    try {
      await UserService.sign_up(newUser); 
      fetchUsers(); 
      setNewUser({ id: 0, login: "", password: "", role: "", name: "" }); 
    } catch (error) {
      setError("Error adding user");
    }
  };
  const handleModify = async () => {
    try {
      await UserService.change_pass(newUser.id.toString(), {
        password: newUser.password,
      });
      fetchUsers();
      setNewUser({ id: 0, login: "", password: "", role: "", name: "" });
    } catch (error) {
      setError("Error modify");
    }
  };

  return (
    <div className="flex flex-col h-screen">
      <NavBarAdmin />
      <div className="flex flex-grow">
        <div className="w-1/2 border-r p-4 flex flex-col justify-center items-center">
          <TextInput
            label="Username"
            type="text"
            name="login"
            value={newUser.login}
            onChange={handleInputChange}
          />
          <TextInput
            label="Password"
            type="password"
            name="password"
            value={newUser.password || ""}
            onChange={handleInputChange}
          />
          <TextInput
            label="Role"
            type="text"
            name="role"
            value={newUser.role}
            onChange={handleInputChange}
          />
          <TextInput
            label="Name"
            type="text"
            name="name"
            value={newUser.name}
            onChange={handleInputChange}
          />
          <div className="flex space-x-2 mt-4">
            <Button
              text="Add"
              backgroundColor="bg-sky-500"
              onClick={handleAddUser}
            />
            <Button
              text="Change Password"
              backgroundColor="bg-yellow-500"
              onClick={handleModify}
            />
            <Button
              text="Delete"
              backgroundColor="bg-red-500"
              onClick={handleDelete}
            />
          </div>
        </div>
        <div className="w-1/2 p-4">
          <UserTable users={users} onUserSelect={handleUserSelect} />
        </div>
      </div>
    </div>
  );
};
