﻿using System;
using System.Drawing;
using System.Windows.Forms;

namespace MusicRenamerSlin_11_2_2020
{
    /*
     * Auteur: Stijn Lingmont
     * Date: 12-02-2020
     * Description: This class provides all the options for the order list.
     */
    public class OrderList
    {
        private ListBox movingFromSlin { get; set; }
        private ListBox movingToSlin { get; set; }

        //Give the effect of dragging an item
        public void MoveFromListBoxSlin(ListBox m_movingListBoxSlin)
        {
            this.movingFromSlin = m_movingListBoxSlin;

            if (m_movingListBoxSlin.SelectedItem != null)
            {
                m_movingListBoxSlin.DoDragDrop(m_movingListBoxSlin.SelectedItem, DragDropEffects.Move);
            }
        }

        //Give the effect of entering a drop zone
        public void EnterDropRegionSlin(ListBox m_droppingListBoxSlin,DragEventArgs m_enterRegionEventSlin)
        {
            this.movingToSlin = m_droppingListBoxSlin;

            m_enterRegionEventSlin.Effect = DragDropEffects.Move;
        }


        //Add the item in the list it is dropped in
        public void DropInBoxSlin(DragEventArgs m_dragEventSlin)
        {
            Point point = this.movingToSlin.PointToClient(new Point(m_dragEventSlin.X, m_dragEventSlin.Y));
            int index = this.movingToSlin.IndexFromPoint(point);
            object data = m_dragEventSlin.Data.GetData(typeof(String));

            //Removing previous item
            if (this.movingFromSlin != null)
                movingFromSlin.Items.Remove(data);
            else
                this.movingToSlin.Items.Remove(data);

            //When you drop the item out of the region with already existing existing items.
            if (index < 0)
            {
                if (this.movingToSlin.Items.Count == 0)
                    index = 0;
                else
                    index = this.movingToSlin.Items.Count;
            }

            this.movingToSlin.Items.Insert(index, data); //Insert new Item
        }
    }
}