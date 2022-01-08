const mock = {
  roles: ["Admin", "Student", "Teacher"],
  users: [
    {
      email: "superadmin@super.user",
      id: 1,
      roles: ["Admin"],
      username: "SSU Admin",
      phone: "+380987654321",
    },
    {
      email: "studentuser@user.user",
      id: 2,
      roles: ["Student"],
      username: "student user",
    },
    {
      email: "mteacher@user.user",
      id: 3,
      roles: ["Teacher"],
      username: "Mega Teacher",
    },
    {
      email: "steacher@user.user",
      id: 4,
      roles: ["Teacher"],
      username: "Super Teacher",
    },
  ],
  groups: [
    {
      id: 0,
      title: "KI-20m-2",
      head: { id: 1 },
      curator: { id: 3 },
    },
    {
      id: 1,
      title: "KI-16-1",
      head: { id: 1 },
      curator: { id: 3 },
    },
  ],
  students: [],
  courses: [
    {
      id: 0,
      title: "Basics of web design",
      description:
        "Basics of the hypertext markup language HTML, CSS, and the JS programming language",
      tacherId: 3,
    },
    {
      id: 1,
      title: "Programming",
      description:
        "Basics of the C programming language, the basics of algorithms",
      tacherId: 4,
    },
    {
      id: 2,
      title: "System Programming",
      description:
        "Fundamentals of systems programming and object-oriented programming language C#",
      tacherId: 4,
    },
  ],
  compSugg: [
    {
      id: 0,
      type: "complaints",
      text: "Test Complaints",
      creatorId: null,
    },
    {
      id: 1,
      type: "suggestions",
      text: "Test Suggestions",
      creatorId: 1,
    },
  ],
};

const addUser = (name, surname, roles) => [
  mock.users.push({
    roles,
    username: `${surname} ${name}`,
    email: `${name[0]}${surname}@mail.mail`.toLowerCase(),
    id: Math.max(...mock.users.map(x => x.id)) + 1,
  }),
];

addUser("Vitaliy", "Petrov", ["Student"]);
addUser("Petro", "Andreev", ["Student"]);
addUser("Anastasia", "Semenova", ["Student"]);
addUser("Natalia", "Molodchenko", ["Student"]);
addUser("Dmytro", "Petrosyan", ["Student"]);
addUser("Vladymir", "Nazarov", ["Student"]);
addUser("Alex", "Rakita", ["Student"]);
addUser("Olena", "Kuraieva", ["Student"]);
addUser("Stanislav", "Pushkarenko", ["Student"]);
addUser("Olha", "Turenko", ["Student"]);
addUser("Alex", "Osokin", ["Student"]);

mock.users.forEach(x => {
  x.phone = "+380987654321";
});

mock.courses.forEach(x => {
  x.avatar = "https://joeschmoe.io/api/v1/random";
  x.content = `Lorem ipsum dolor sit amet, consectetur adipiscing elit,\
    sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.\
    Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi\
    ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit\
    in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur \
    sint occaecat cupidatat non proident, sunt in culpa qui officia\
    deserunt mollit anim id est laborum.`;
});

const studentUsers = mock.users.filter(x => x.roles.includes("Student"));
const threshold = Math.round(studentUsers.length / 2);
const maxStudentId = Math.max(...mock.students.map(x => x.id)) || 0;
studentUsers.forEach((x, i) =>
  mock.students.push({
    id: maxStudentId + i,
    groupId: i < threshold ? 0 : 1,
    userId: x.id,
  })
);

export default mock;
