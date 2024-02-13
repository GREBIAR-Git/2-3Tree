# Описание

B-дерево типа 2-3 - является структурой данных, используемой для организации и хранения отсортированных данных. Оно состоит из узлов, которые могут содержать от одного до трех дочерних узлов и от одного до двух ключей данных. В B-дереве типа 2-3 все листовые узлы находятся на одном уровне, что обеспечивает эффективный поиск и доступ к данным.

# Cвойства:

- Нелистовые вершины имеют либо двух, либо трех потомков, обеспечивая баланс и эффективность структуры дерева.
- Нелистовая вершина с двумя потомками хранит максимальное значение левого поддерева, в то время как вершина с тремя потомками хранит два значения: максимум левого поддерева и максимум центрального поддерева.
- Потомки упорядочены по значению максимума поддерева каждого сына, обеспечивая быстрый поиск и сортировку.
- Все листья расположены на одной глубине, обеспечивая равномерность поиска и операций вставки/удаления.
- Высота B-дерева типа 2-3 оценивается как O(log n), где n - количество элементов в дереве, что позволяет эффективно выполнять операции поиска, вставки и удаления.

# Демонстрация работы программы

<div>
  <img width=580 height=340 src="https://github.com/GREBIAR-Git/2-3Tree/assets/74742355/1698ca69-d72c-4711-a4b3-0028122c9d94">
</div>

