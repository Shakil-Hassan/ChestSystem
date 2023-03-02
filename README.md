<h1>ChestSystem</h1>
<p>ChestSystem is a simple inventory system for Unity games, written in C#. It provides a way for managing items and inventory containers (such as chests) in a game.</p>
<h2>Features</h2>
<ul>
  <li>Add, remove, and modify items in an inventory container.</li>
  <li>Chest queueing: Players can queue up to unlock one chest at a time.</li>
  <li>Chest timers: Chests have a timer that counts down until they can be opened.</li>
  <li>Gems: Players can use gems to unlock chests instantly or speed up their timers.</li>
  <li>Random chest rewards: Chests can contain random rewards, such as gold, cards, or items.</li>
  <li>Customizable chest types: Developers can define their own chest types and rewards.</li>
  <li>UI elements: ChestSystem provides UI elements for displaying chest timers and rewards.</li>
</ul>
<h2>Core Logic</h2>
<p>The core logic of the ChestSystem is based on the Model-View-Controller (MVC) pattern, with some additional classes to manage inventory containers and items.</p>
<ul>
  <li><strong>Model:</strong> The Inventory class represents the data of an inventory, including its size, the items it contains, and the maximum stack size of each item. The Item class represents an individual item in an inventory, with a name, type, and count.</li>
  <li><strong>View:</strong> The InventoryUI class provides a user interface for displaying the contents of an inventory, allowing the user to interact with the items.</li>
  <li><strong>Controller:</strong> The InventoryController class manages the interaction between the view and model classes, updating the inventory data based on user input and updating the view to reflect the current state of the inventory.</li>
</ul>
<h2>Design Patterns</h2>
<p>ChestSystem uses the following design patterns:</p>
<ul>
  <li><strong>Singleton Pattern:</strong> The InventoryManager class is a singleton that provides a global access point to the inventory data and controllers.</li>
  <li><strong>Observer Pattern:</strong> The Item class implements the observer pattern to notify the inventory controller when its count changes, allowing for automatic updates to the UI.</li>
</ul>
<h2>Usage</h2>
<p>To use ChestSystem in a Unity game, follow these steps:</p>
<ol>
  <li>Clone the ChestSystem repository to your local machine.</li>
  <li>Import the ChestSystem folder into your Unity project.</li>
  <li>Create an instance of the Inventory class to represent your inventory data.</li>
  <li>Create an instance of the InventoryUI class to display the inventory UI to the user.</li>
  <li>Create an instance of the InventoryController class to manage the interaction between the inventory data and the UI.</li>
</ol>
<h2>License</h2>
<p>This project is licensed under the MIT License - see the LICENSE file for details.</p>
